using Core.Dto;

namespace StudentManagementSystem.Dto.Concrete.Teacher
{
    public class TeacherReadDto : IReadDto
    {
        public int Id { get; set; }
        public string Expertise { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
    }
}
