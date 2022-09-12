using Core.DataAccess;
using Core.Exceptions;
using Core.Paging;
using Core.Utilities.Message;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Mapster;
using Microsoft.EntityFrameworkCore.Query;
using StudentManagementSystem.Business.Services.Abstract;
using StudentManagementSystem.Dto.Concrete.Student;
using StudentManagementSystem.Entity.Concrete;
using System.Linq.Expressions;

namespace StudentManagementSystem.Business.Services.Concrete
{
    public class StudentManager : BaseManager<Student, StudentWriteDto, StudentReadDto>, IStudentService
    {
        public StudentManager(IRepository<Student> repository, ILanguageMessage languageMessage) : base(repository, languageMessage)
        {
        }

        public override async Task<DataResult<StudentReadDto>> AddAsync(StudentWriteDto writeDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(writeDto.Password, out passwordHash, out passwordSalt);

            Student entity = writeDto.Adapt<Student>();

            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;

            Student addedEntity = await _repository.AddAsync(entity);

            if (addedEntity == null)
                throw new BusinessException(_languageMessage.FailureAdd);

            return new SuccessDataResult<StudentReadDto>(addedEntity.Adapt<StudentReadDto>(), _languageMessage.SuccessAdd);
        }

        public async override Task<DataResult<StudentReadDto>> UpdateAsync(int id, StudentWriteDto writeDto)
        {
            return await base.UpdateAsync(id, writeDto);
        }

        public override async Task<DataResult<StudentReadDto>> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }

        public override async Task<DataResult<StudentReadDto>> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }


        public override async Task<DataResult<IPaginate<StudentReadDto>>> GetListAsync(
            Expression<Func<Student, bool>>? predicate = null,
            Func<IQueryable<Student>, IOrderedQueryable<Student>>? orderBy = null,
            Func<IQueryable<Student>, IIncludableQueryable<Student, object>>?
            include = null, int index = 0, int size = 10, bool enamleTracking = true,
            CancellationToken cancellationToken = default)
        {
            return await base.GetListAsync(predicate, orderBy, include, index, size, enamleTracking, cancellationToken);
        }
    }
}
