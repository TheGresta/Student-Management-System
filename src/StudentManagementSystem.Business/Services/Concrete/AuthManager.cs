using Core.Dto;
using Core.Entity.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using StudentManagementSystem.Business.Services.Abstract;
using StudentManagementSystem.DataAccess.Abstract;

namespace StudentManagementSystem.Business.Services.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserDal _userDal;

        public AuthManager(ITokenHelper tokenHelper, IUserDal userDal)
        {
            _tokenHelper = tokenHelper;
            _userDal = userDal;
        }

        public async Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user)
        {
            Role claims = await _userDal.GetClaimAsync(user);
            AccessToken token = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(token);
        }

        public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto)
        {
            User userResult = await _userDal.GetAsync(x => x.Email == userForLoginDto.Email);
            if (userResult == null)
                return new ErrorDataResult<User>("User Not Found");
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userResult.PasswordHash, userResult.PasswordSalt))
                return new ErrorDataResult<User>("Password is Wrong");
            return new SuccessDataResult<User>(userResult, "Successfuly Login");
        }
    }
}
