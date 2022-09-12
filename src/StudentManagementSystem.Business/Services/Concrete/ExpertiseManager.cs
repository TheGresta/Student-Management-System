using Core.Paging;
using Core.Utilities.Message;
using Core.Utilities.Result;
using Microsoft.EntityFrameworkCore.Query;
using StudentManagementSystem.Business.Services.Abstract;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.Dto.Concrete.Expertise;
using StudentManagementSystem.Entity.Concrete;
using System.Linq.Expressions;

namespace StudentManagementSystem.Business.Services.Concrete
{
    public class ExpertiseManager : BaseManager<Expertise, ExpertiseWriteDto, ExpertiseReadDto>, IExpertiseService
    {
        public ExpertiseManager(IExpertiseDal repository, ILanguageMessage languageMessage) : base(repository, languageMessage)
        {
        }

        public override async Task<DataResult<ExpertiseReadDto>> AddAsync(ExpertiseWriteDto writeDto)
        {
            return await base.AddAsync(writeDto);
        }

        public async override Task<DataResult<ExpertiseReadDto>> UpdateAsync(int id, ExpertiseWriteDto writeDto)
        {
            return await base.UpdateAsync(id, writeDto);
        }

        public override async Task<DataResult<ExpertiseReadDto>> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }

        public override async Task<DataResult<ExpertiseReadDto>> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }


        public override async Task<DataResult<IPaginate<ExpertiseReadDto>>> GetListAsync(
            Expression<Func<Expertise, bool>>? predicate = null,
            Func<IQueryable<Expertise>, IOrderedQueryable<Expertise>>? orderBy = null,
            Func<IQueryable<Expertise>, IIncludableQueryable<Expertise, object>>?
            include = null, int index = 0, int size = 10, bool enamleTracking = true,
            CancellationToken cancellationToken = default)
        {
            return await base.GetListAsync(predicate, orderBy, include, index, size, enamleTracking, cancellationToken);
        }
    }
}
