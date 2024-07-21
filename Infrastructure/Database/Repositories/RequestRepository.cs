using Infrastructure.Database.Entities;
using Npgsql;
using NPoco;

namespace Infrastructure.Database.Repositories
{
    public class RequestRepository : IRepository<RequestEntity>
    {
        private readonly IDatabase _db;

        public RequestRepository() 
        {
            var _conn = new NpgsqlConnection("Server=pandpostgresql.postgres.database.azure.com;Database=pandurx;Port=5432;User Id=dbadmin;Password=P@ssw0rd;Ssl Mode=VerifyFull;");
            _db = new NPoco.Database(_conn);
        }

        public async Task Add<RequestEntity>(RequestEntity entity)
        {
            _db.Connection.Open();

            await _db.InsertAsync<RequestEntity>(entity);
            _db.Connection.Close();
        }

        public async Task<RequestEntity> GetById(Guid requestId)
        {
            _db.Connection.Open();
            var result = await _db.SingleByIdAsync<RequestEntity>(requestId);
            _db.Connection.Close();
            return result;
        }
    }
}
