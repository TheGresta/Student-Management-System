using Core.Entity.Concrete;
using Core.Exceptions;
using Core.Paging;
using Core.Utilities.Message;
using Core.Utilities.Result;
using Mapster;
using Microsoft.EntityFrameworkCore.Query;
using StudentManagementSystem.Business.Services.Abstract;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.DataAccess.Context;
using StudentManagementSystem.Dto.Concrete.Grade;
using StudentManagementSystem.Dto.Concrete.Lesson;
using StudentManagementSystem.Dto.Concrete.Student;
using StudentManagementSystem.Dto.Concrete.User;
using StudentManagementSystem.Entity.Concrete;
using System.Linq.Expressions;

namespace StudentManagementSystem.Business.Services.Concrete
{
    public class LessonManager : BaseManager<Lesson, LessonWriteDto, LessonReadDto>, ILessonService
    {
        private readonly StudentManagementSystemDbContext _context;
        public LessonManager(ILessonDal repository, ILanguageMessage languageMessage, StudentManagementSystemDbContext context) : base(repository, languageMessage)
        {
            _context = context;
        }

        public override async Task<DataResult<LessonReadDto>> AddAsync(LessonWriteDto writeDto)
        {
            Lesson entity = writeDto.Adapt<Lesson>();
            List<Student> StudentList = new();

            var noList = writeDto.StudentIdList;
            
            foreach (var no in noList)
            {
                StudentList.Add(_context.Students.SingleOrDefault(x => x.StudentNo == no));
            }

            entity.StudentList = StudentList;

            Lesson addedEntity = await _repository.AddAsync(entity);

            if (addedEntity == null)
                throw new BusinessException(_languageMessage.FailureAdd);

            return new SuccessDataResult<LessonReadDto>(addedEntity.Adapt<LessonReadDto>(), _languageMessage.SuccessAdd);
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
