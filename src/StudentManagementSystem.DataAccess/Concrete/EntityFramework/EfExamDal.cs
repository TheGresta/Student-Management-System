using Core.DataAccess.EntityFramework;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.DataAccess.Context;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class EfExamDal : EfRepositoryBase<Exam, StudentManagementSystemDbContext>, IExamDal
    {
        private readonly StudentManagementSystemDbContext _context;
        public EfExamDal(StudentManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
