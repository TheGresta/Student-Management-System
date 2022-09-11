using Core.DataAccess.EntityFramework;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.DataAccess.Context;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class EfTeacherDal : EfRepositoryBase<Teacher, StudentManagementSystemDbContext>, ITeacherDal
    {
        private readonly StudentManagementSystemDbContext _context;
        public EfTeacherDal(StudentManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
