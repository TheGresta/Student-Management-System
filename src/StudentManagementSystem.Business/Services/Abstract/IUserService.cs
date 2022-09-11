using Core.Entity.Concrete;
using StudentManagementSystem.Dto.Concrete.User;

namespace StudentManagementSystem.Business.Services.Abstract
{
    public interface IUserService : IBaseService<User, UserWriteDto, UserReadDto>
    {
    }
}
