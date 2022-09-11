using Core.Dto;

namespace StudentManagementSystem.Dto.Concrete.Grade
{
    public class GradeReadDto : IReadDto
    {
        public int Id { get; set; }
        public decimal GradeValue { get; set; }
    }
}
