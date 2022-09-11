using Core.DataAccess;
using Core.Entity.Concrete;

namespace StudentManagementSystem.DataAccess.Abstract
{
    public interface IUserDal : IRepository<User>
    {
        Task<Role> GetClaimAsync(User user);
    }
}
