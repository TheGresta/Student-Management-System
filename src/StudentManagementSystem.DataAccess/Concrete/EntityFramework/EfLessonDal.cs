using Core.DataAccess.EntityFramework;
using StudentManagementSystem.DataAccess.Abstract;
using StudentManagementSystem.DataAccess.Context;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class EfLessonDal : EfRepositoryBase<Lesson, StudentManagementSystemDbContext>, ILessonDal
    {
        private readonly StudentManagementSystemDbContext _context;
        public EfLessonDal(StudentManagementSystemDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
