using Core.Dto;

namespace StudentManagementSystem.Dto.Concrete.Teacher
{
    public class TeacherWriteDto : IWriteDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ExpertiseId { get; set; }
    }
}
