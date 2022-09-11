using StudentManagementSystem.Dto.Concrete.Teacher;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.Business.Services.Abstract
{
    public interface ITeacherService : IBaseService<Teacher, TeacherWriteDto, TeacherReadDto>
    {
    }
}
