using Core.DataAccess.EntityFramework;
using Core.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.DataAccess.Context;

namespace StudentManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfRepositoryBase<User, StudentManagementSystemDbContext>, IUserDal
    {
        private readonly StudentManagementSystemDbContext _context;
        public EfUserDal(StudentManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Role> GetClaimAsync(User user)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == user.RoleId);

            return role;
        }
    }
}
