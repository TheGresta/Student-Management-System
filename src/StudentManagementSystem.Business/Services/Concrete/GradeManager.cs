using Core.Paging;
using Core.Utilities.Message;
using Core.Utilities.Result;
using Microsoft.EntityFrameworkCore.Query;
using StudentManagementSystem.Business.Services.Abstract;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.Dto.Concrete.Expertise;
using StudentManagementSystem.Dto.Concrete.Grade;
using StudentManagementSystem.Entity.Concrete;
using System.Linq.Expressions;

namespace StudentManagementSystem.Business.Services.Concrete
{
    public class GradeManager : BaseManager<Grade, GradeWriteDto, GradeReadDto>, IGradeService
    {
        public GradeManager(IGradeDal repository, ILanguageMessage languageMessage) : base(repository, languageMessage)
        {
        }

        public override async Task<DataResult<GradeReadDto>> AddAsync(GradeWriteDto writeDto)
        {
            return await base.AddAsync(writeDto);
        }

        public async override Task<DataResult<GradeReadDto>> UpdateAsync(int id, GradeWriteDto writeDto)
        {
            return await base.UpdateAsync(id, writeDto);
        }

        public override async Task<DataResult<GradeReadDto>> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }

        public override async Task<DataResult<GradeReadDto>> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }


        public override async Task<DataResult<IPaginate<GradeReadDto>>> GetListAsync(
            Expression<Func<Grade, bool>>? predicate = null,
            Func<IQueryable<Grade>, IOrderedQueryable<Grade>>? orderBy = null,
            Func<IQueryable<Grade>, IIncludableQueryable<Grade, object>>?
            include = null, int index = 0, int size = 10, bool enamleTracking = true,
            CancellationToken cancellationToken = default)
        {
            return await base.GetListAsync(predicate, orderBy, include, index, size, enamleTracking, cancellationToken);
        }
    }
}
