using Core.Dto;

namespace StudentManagementSystem.Dto.Concrete.Expertise
{
    public class ExpertiseReadDto : IReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
