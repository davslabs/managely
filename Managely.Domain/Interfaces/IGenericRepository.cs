using System.Linq.Expressions;

namespace Managely.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid id);
        IQueryable<T> Includes(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
