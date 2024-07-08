using Infrastructure.Database.Contracts;
using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Infrastructure.Database
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly ILogger _logger;
        //private readonly IUserAccessor _currentUser;

        public AppDbContext(DbContextOptions options)
            : base(options)
        {
            //_logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseNpgsql("Server=pandpostgresql.postgres.database.azure.com;Database=pandurx;Port=5432;User Id=dbadmin;Password=P@ssw0rd;Ssl Mode=VerifyFull;");
        }

        public DbSet<RequestEntity> Request { get; set; } = null!;


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            ProcessAuditFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ProcessAuditFields()
        {
            var trackedEntries = ChangeTracker.Entries();
            foreach (var trackedEntry in trackedEntries)
            {
                SetCreatedFields(trackedEntry, DateTime.UtcNow);
                SetUpdatedFields(trackedEntry, DateTime.UtcNow);
                SetDeletedFields(trackedEntry, DateTime.UtcNow);
            }
        }

        private void SetCreatedFields(EntityEntry trackedEntry, DateTime now)
        {
            if (trackedEntry.State != EntityState.Added)
            {
                return;
            }

            if (trackedEntry.Entity is ICreatableEntity creatable)
            {
                creatable.CreatedOn = now;
                //creatable.CreatedBy = _currentUser.Id;
            }

            if (trackedEntry.Entity is not IDeletableEntity deletable)
            {
                return;
            }

            deletable.DeletedOn = null;
            deletable.DeletedBy = null;
            deletable.DeletedReason = null;
        }

        private void SetUpdatedFields(EntityEntry trackedEntry, DateTime now)
        {
            if (trackedEntry.State is EntityState.Detached or EntityState.Unchanged)
            {
                return;
            }

            if (trackedEntry.Entity is not IUpdateableEntity updateable)
            {
                return;
            }

            updateable.UpdatedDateUTC = now;
            //updateable.UpdatedBy = _currentUser.Id;
        }

        private void SetDeletedFields(EntityEntry trackedEntry, DateTime now)
        {
            if (trackedEntry.State != EntityState.Deleted)
            {
                return;
            }

            if (trackedEntry.Entity is not IDeletableEntity deletable)
            {
                return;
            }

            deletable.DeletedOn = now;
            //deletable.DeletedBy = _currentUser.Id;
            trackedEntry.State = EntityState.Modified;
        }

        Task IAppDbContext.SaveChangesAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
