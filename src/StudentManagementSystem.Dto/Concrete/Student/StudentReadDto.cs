using Core.Dto;

namespace StudentManagementSystem.Dto.Concrete.Student
{
    public class StudentReadDto : IReadDto
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public decimal Grade { get; set; }
        public DateTime Created { get; set; }
    }
}
