using StudentManagementSystem.Dto.Concrete.Grade;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.Business.Services.Abstract
{
    public interface IGradeService : IBaseService<Grade, GradeWriteDto, GradeReadDto>
    {
    }
}
