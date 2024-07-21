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

        //public void ManageConnection()
        //{
        //    using (var db = _db) {
        //        db.Connection.Open();
        //    }
        //}

        public async Task Add<RequestEntity>(RequestEntity entity)
        {
            //_db.Connection.Open();
            await _db.InsertAsync<RequestEntity>(entity);
            //_db.Connection.Close();
        }

        public async Task<RequestEntity> GetById(Guid requestId)
        {
            //_db.Connection.Open();
            var result = await _db.SingleByIdAsync<RequestEntity>(requestId);
            //_db.Connection.Close();
            return result;
        }
    }
}
