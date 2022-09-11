using Core.Aspects.Validation;
using Core.DataAccess;
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
using StudentManagementSystem.Dto.Concrete.User;
using System.Linq.Expressions;

namespace StudentManagementSystem.Business.Services.Concrete
{
    public class UserManager : BaseManager<User, UserWriteDto, UserReadDto>, IUserService
    {
        public UserManager(IUserDal repository, ILanguageMessage languageMessage) : base(repository, languageMessage)
        {
        }

        public override async Task<DataResult<UserReadDto>> AddAsync(UserWriteDto writeDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(writeDto.Password, out passwordHash, out passwordSalt);

            User entity = writeDto.Adapt<User>();

            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;

            User addedEntity = await _repository.AddAsync(entity);

            if (addedEntity == null)
                throw new BusinessException(_languageMessage.FailureAdd);
          
            return new SuccessDataResult<UserReadDto>(addedEntity.Adapt<UserReadDto>(), _languageMessage.SuccessAdd);
        }

        public override async Task<DataResult<UserReadDto>> DeleteAsync(int id)
        {
            return await base.DeleteAsync(id);
        }

        public async override Task<DataResult<UserReadDto>> UpdateAsync(int id, UserWriteDto writeDto)
        {
            return await base.UpdateAsync(id, writeDto);
        }

        public override Task<DataResult<IPaginate<UserReadDto>>> GetListAsync(
            Expression<Func<User, bool>>? predicate = null,
            Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
            Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
            int index = 0, int size = 10, bool enamleTracking = true,
            CancellationToken cancellationToken = default)
        {
            return base.GetListAsync(predicate, orderBy, include, index, size, enamleTracking, cancellationToken);
        }

        public override async Task<DataResult<UserReadDto>> GetByIdAsync(int id)
        {
            return await base.GetByIdAsync(id);
        }
    }
}
