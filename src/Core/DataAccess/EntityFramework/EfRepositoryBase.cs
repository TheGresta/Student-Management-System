using Core.Dynamic;
using Core.Entity;
using Core.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseEntity, new()
        where TContext : DbContext, new()
    {
        protected TContext Context { get; }

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            int row = await Context.SaveChangesAsync();
            TEntity rtr = (row > 0) ? entity : null;
            return rtr;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            await Context.AddRangeAsync(entities);
            int row = await Context.SaveChangesAsync();
            bool rtr = (row == entities.Count) ? true : false;
            return rtr;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            int row = await Context.SaveChangesAsync();
            TEntity rtr = (row > 0) ? entity : null;
            return rtr;

        }

        public async Task<IPaginate<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>,
            IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>,
            IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0, int size = 10,
            bool enableTracking = true,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>().AsQueryable();

            if (tracking == false)
                data.AsNoTracking();

            TEntity entity = await data.SingleOrDefaultAsync(predicate);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            int row = await Context.SaveChangesAsync();
            TEntity rtr = (row > 0) ? entity : null;
            return rtr;
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }
    }
}
