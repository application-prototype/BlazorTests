using Infrastructure.Database.Entities;
using Infrastructure.Database.Repositories;
using Npgsql;
using NPoco;

namespace Infrastructure.Database
{
    // DbContext instance represents a session with the database and can be used to query and save instances of entities. DbContext 
    // is a combination of Unit of Work and Repository patterns
    // reference: https://www.milanjovanovic.tech/blog/using-multiple-ef-core-dbcontext-in-single-application
    public class RequestDbContext : IRequestDbContext
    {
        private IDatabase _database;
        private NpgsqlConnection _conn;

        public IRepository<RequestEntity> RequestRepository { get; private set; }

        public RequestDbContext()
        {
            _conn = new NpgsqlConnection("Server=pandpostgresql.postgres.database.azure.com;Database=pandurx;Port=5432;User Id=dbadmin;Password=P@ssw0rd;Ssl Mode=VerifyFull;");
            _database = new NPoco.Database(_conn);
            RequestRepository = new RequestRepository();
        }

        public async Task Add<T>(T entity)
        {
            await RequestRepository.Add(entity);
        }

        public async Task<RequestEntity> GetRequestById(Guid requestId)
        {
            var result = await RequestRepository.GetById(requestId);
            return result;
        }
    }
}
