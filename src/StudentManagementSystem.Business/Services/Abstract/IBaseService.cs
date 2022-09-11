using Core.Dto;
using Core.Entity;
using Core.Paging;
using Core.Utilities.Result;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace StudentManagementSystem.Business.Services.Abstract
{
    public interface IBaseService<TEntity, TWriteDto, TReadDto>
        where TEntity : BaseEntity, new()
        where TWriteDto : class, IWriteDto, new()
        where TReadDto : class, IReadDto, new()
    {
        Task<DataResult<TReadDto>> AddAsync(TWriteDto writeDto);
        Task<DataResult<TReadDto>> UpdateAsync(int id, TWriteDto writeDto);
        Task<DataResult<TReadDto>> DeleteAsync(int id);
        Task<DataResult<TReadDto>> GetByIdAsync(int id);
        Task<DataResult<IPaginate<TReadDto>>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0, int size = 10,
            bool enamleTracking = true,
            CancellationToken cancellationToken = default);
    }
}
