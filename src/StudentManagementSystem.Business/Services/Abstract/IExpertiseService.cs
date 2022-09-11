using StudentManagementSystem.Dto.Concrete.Expertise;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.Business.Services.Abstract
{
    public interface IExpertiseService : IBaseService<Expertise, ExpertiseWriteDto, ExpertiseReadDto>
    {
    }
}
