using Core.Dto;
using Core.Entity.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.JWT;

namespace StudentManagementSystem.Business.Services.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto);
        Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user);
    }
}
