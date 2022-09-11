using StudentManagementSystem.Dto.Concrete.Student;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.Business.Services.Abstract
{
    public interface IStudentService : IBaseService<Student, StudentWriteDto, StudentReadDto>
    {
    }
}
