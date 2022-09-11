using StudentManagementSystem.Dto.Concrete.Exam;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.Business.Services.Abstract
{
    public interface IExamService : IBaseService<Exam, ExamWriteDto, ExamReadDto>
    {
    }
}
