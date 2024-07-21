using Infrastructure.Database.Entities;
using Infrastructure.Database.Repositories;

namespace Infrastructure.Database
{
    public interface IRequestDbContext
    {
        public Task<RequestEntity> GetRequestById(Guid requestId);
        public Task Add<T>(T entity);
    }
}
