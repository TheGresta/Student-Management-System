using StudentManagementSystem.Dto.Concrete.Lesson;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.Business.Services.Abstract
{
    public interface ILessonService : IBaseService<Lesson, LessonWriteDto, LessonReadDto>
    {
    }
}
