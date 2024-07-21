using Infrastructure.Database.Entities;
using Infrastructure.Database.Repositories;
using Npgsql;
using NPoco;

namespace Infrastructure.Database
{
    // DbContext instance represents a session with the database and can be used to query and save instances of entities. DbContext 
    // is a combination of Unit of Work and Repository patterns
    // reference: https://www.milanjovanovic.tech/blog/using-multiple-ef-core-dbcontext-in-single-application
    // testing strategy: https://medium.com/@jaydeepvpatil225/unit-of-work-with-generic-repository-implementation-using-net-core-6-web-api-23d159c63dd4

    public class RequestDbContext : IRequestDbContext
    {
        public IRepository<RequestEntity> RequestRepository { get; private set; }

        public RequestDbContext()
        {
            // get connection string on runtime?
            var connection = new NpgsqlConnection("Server=pandpostgresql.postgres.database.azure.com;Database=pandurx;Port=5432;User Id=dbadmin;Password=P@ssw0rd;Ssl Mode=VerifyFull;");
            //var database = new NPoco.Database(connection);
            var factory = Npgsql.NpgsqlFactory.Instance;
            var database = new NPoco.Database(
                "Server=pandpostgresql.postgres.database.azure.com;Database=pandurx;Port=5432;User Id=dbadmin;Password=P@ssw0rd;Ssl Mode=VerifyFull;",
                DatabaseType.PostgreSQL,
                factory);
            RequestRepository = new RequestRepository(database);
        }

        // defines generic method
        public async Task Add<T>(T entity)
        {
            await RequestRepository.Add(entity);
        }

        public async Task<RequestEntity> GetRequestById(Guid requestId)
        {
            return await RequestRepository.GetById(requestId);
        }
    }
}
