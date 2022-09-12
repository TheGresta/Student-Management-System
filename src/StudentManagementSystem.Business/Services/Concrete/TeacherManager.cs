using Core.Entity.Concrete;
using Core.Exceptions;
using Core.Paging;
using Core.Utilities.Message;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Mapster;
using Microsoft.EntityFrameworkCore.Query;
using StudentManagementSystem.Business.Services.Abstract;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.Dto.Concrete.Teacher;
using StudentManagementSystem.Dto.Concrete.User;
using StudentManagementSystem.Entity.Concrete;
using System.Linq.Expressions;

namespace StudentManagementSystem.Business.Services.Concrete
{
    public class TeacherManager : BaseManager<Teacher, TeacherWriteDto, TeacherReadDto>, ITeacherService
    {
        public TeacherManager(ITeacherDal repository, ILanguageMessage languageMessage) : base(repository, languageMessage)
        {
        }

        public override async Task<DataResult<TeacherReadDto>> AddAsync(TeacherWriteDto writeDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(writeDto.Password, out passwordHash, out passwordSalt);

            Teacher entity = writeDto.Adapt<Teacher>();

            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;

            Teacher addedEntity = await _repository.AddAsync(entity);

            if (addedEntity == null)
                throw new BusinessException(_languageMessage.FailureAdd);

            return new SuccessDataResult<TeacherReadDto>(addedEntity.Adapt<TeacherReadDto>(), _languageMessage.SuccessAdd);
        }

        public override async Task<DataResult<TeacherReadDto>> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }

        public async override Task<DataResult<TeacherReadDto>> UpdateAsync(int id, TeacherWriteDto writeDto)
        {
            return await base.UpdateAsync(id, writeDto);
        }

        public override Task<DataResult<IPaginate<TeacherReadDto>>> GetListAsync(
            Expression<Func<Teacher, bool>>? predicate = null,
            Func<IQueryable<Teacher>, IOrderedQueryable<Teacher>>? orderBy = null,
            Func<IQueryable<Teacher>, IIncludableQueryable<Teacher, object>>? include = null,
            int index = 0, int size = 10, bool enamleTracking = true,
            CancellationToken cancellationToken = default)
        {
            return base.GetListAsync(predicate, orderBy, include, index, size, enamleTracking, cancellationToken);
        }

        public override async Task<DataResult<TeacherReadDto>> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }
    }
}
