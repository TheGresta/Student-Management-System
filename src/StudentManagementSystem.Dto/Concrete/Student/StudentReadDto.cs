using Core.Dto;

namespace StudentManagementSystem.Dto.Concrete.Student
{
    public class StudentReadDto : IReadDto
    {
        public int Id { get; set; }
        public string StudentNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Grade { get; set; }
        public DateTime Created { get; set; }
    }
}
