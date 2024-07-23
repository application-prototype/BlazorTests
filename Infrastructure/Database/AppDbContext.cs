using Infrastructure.Database.Models;
using Infrastructure.Database.Models.Audit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection;

namespace Infrastructure.Database
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private readonly ILogger _logger;
        //private readonly IUserAccessor _currentUser;

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            //_logger = logger;
        }

        // represents the tables that entities represent
        public DbSet<RequestEntity> Requests { get; set; } = null!;
        public DbSet<SubRequestEntity> Subs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // reference: https://learn.microsoft.com/en-us/ef/core/modeling/relationships/one-to-one
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<RequestEntity>()
                .Property(x => x.Id)
                .IsRequired(); // Id is required

            modelBuilder.Entity<RequestEntity>()
                .HasOne(x => x.SubRequest) // define 1:1 relationship
                .WithOne(x => x.Request)
                .HasForeignKey<SubRequestEntity>(x => x.RequestId)
                .IsRequired();

            modelBuilder.Entity<SubRequestEntity>()
                .Property(x => x.Id)
                .IsRequired(); // Id is required
        }


        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
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

    }
}
