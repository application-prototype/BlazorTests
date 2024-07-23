using Infrastructure.Database.Entities;
using Infrastructure.Database.Models;

namespace Infrastructure.Database
{
    public interface ISubRequestDbContext
    {
        public Task<SubRequestEntity> GetRequestById(Guid requestId);
        public Task Add<T>(T entity);
    }
}
