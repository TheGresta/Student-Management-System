using Core.Exceptions;
using Core.Paging;
using Core.Utilities.Message;
using Core.Utilities.Result;
using Mapster;
using Microsoft.EntityFrameworkCore.Query;
using StudentManagementSystem.Business.Services.Abstract;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.Dto.Concrete.Exam;
using StudentManagementSystem.Entity.Concrete;
using System.Linq.Expressions;

namespace StudentManagementSystem.Business.Services.Concrete
{
    public class ExamManager : BaseManager<Exam, ExamWriteDto, ExamReadDto>, IExamService
    {
        public ExamManager(IExamDal repository, ILanguageMessage languageMessage) : base(repository, languageMessage)
        {
        }

        public override async Task<DataResult<ExamReadDto>> AddAsync(ExamWriteDto writeDto)
        {
            Exam entity = writeDto.Adapt<Exam>();
            List<Grade> GradeList = writeDto.StudentList.Adapt<List<Grade>>();

            entity.StudentList = GradeList;

            Exam addedEntity = await _repository.AddAsync(entity);

            if (addedEntity == null)
                throw new BusinessException(_languageMessage.FailureAdd);

            return new SuccessDataResult<ExamReadDto>(addedEntity.Adapt<ExamReadDto>(), _languageMessage.SuccessAdd);
        }

        public override async Task<DataResult<ExamReadDto>> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }

        public async override Task<DataResult<ExamReadDto>> UpdateAsync(int id, ExamWriteDto writeDto)
        {
            return await base.UpdateAsync(id, writeDto);
        }

        public override Task<DataResult<IPaginate<ExamReadDto>>> GetListAsync(
            Expression<Func<Exam, bool>>? predicate = null,
            Func<IQueryable<Exam>, IOrderedQueryable<Exam>>? orderBy = null,
            Func<IQueryable<Exam>, IIncludableQueryable<Exam, object>>? include = null,
            int index = 0, int size = 10, bool enamleTracking = true,
            CancellationToken cancellationToken = default)
        {
            return base.GetListAsync(predicate, orderBy, include, index, size, enamleTracking, cancellationToken);
        }

        public override async Task<DataResult<ExamReadDto>> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }
    }
}
}
