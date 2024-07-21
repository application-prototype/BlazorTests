namespace Infrastructure.Database.Repositories
{
    public interface IRepository<T>
    {
        Task<T> GetById(Guid id);
        Task Add<T>(T entity);
    }
}
