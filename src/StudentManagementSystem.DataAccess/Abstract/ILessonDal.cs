using Core.DataAccess;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.DataAccess.Abstract
{
    public interface ILessonDal : IRepository<Lesson>
    {
    }
}
