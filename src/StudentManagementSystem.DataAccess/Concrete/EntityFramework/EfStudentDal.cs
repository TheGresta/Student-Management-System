using Core.DataAccess.EntityFramework;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.DataAccess.Context;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class EfStudentDal : EfRepositoryBase<Student, StudentManagementSystemDbContext>, IStudentDal
    {
        private readonly StudentManagementSystemDbContext _context;
        public EfStudentDal(StudentManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
