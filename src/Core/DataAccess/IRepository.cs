using Core.Entity;
using Core.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IRepository<T> : IQuery<T>
        where T : BaseEntity, new()
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<IPaginate<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            int index = 0, int size = 10,
            bool enamleTracking = true,
            CancellationToken cancellationToken = default);
    }
}
