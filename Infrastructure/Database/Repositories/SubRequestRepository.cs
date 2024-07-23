using Infrastructure.Database.Entities;
using Infrastructure.Database.Models;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Repositories
{
    internal class SubRequestRepository : IRepository<SubRequestEntity>
    {
        private readonly IDatabase _db;

        public SubRequestRepository(IDatabase db)
        {
            _db = db;
        }


        public async Task Add<SubRequestEntity>(SubRequestEntity entity)
        {
            await _db.InsertAsync<SubRequestEntity>(entity);
        }

        public async Task<SubRequestEntity> GetById(Guid requestId)
        {
            var result = await _db.Query<SubRequestEntity>().FirstOrDefaultAsync(x => x.RequestId == requestId);
            //var result = await _db.SingleByIdAsync<SubRequestEntity>(requestId);
            return result;
        }
    }
}
