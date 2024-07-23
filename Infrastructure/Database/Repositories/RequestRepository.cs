using Infrastructure.Database.Entities;
using NPoco;

namespace Infrastructure.Database.Repositories
{
    // repository focuses on data access and manipulation
    public class RequestRepository : IRepository<RequestEntity>
    {
        private readonly IDatabase _db;

        public RequestRepository(IDatabase db) 
        {
            _db = db;
        }

        public async Task Add<RequestEntity>(RequestEntity entity)
        {
            await _db.InsertAsync<RequestEntity>(entity);
        }

        public async Task<RequestEntity> GetById(Guid requestId)
        {
            var result = await _db.SingleByIdAsync<RequestEntity>(requestId);
            return result;
        }
    }
}
