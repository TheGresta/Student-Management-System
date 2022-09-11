using Core.DataAccess.EntityFramework;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.DataAccess.Context;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class EfGradeDal : EfRepositoryBase<Grade, StudentManagementSystemDbContext>, IGradeDal
    {
        private readonly StudentManagementSystemDbContext _context;
        public EfGradeDal(StudentManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
