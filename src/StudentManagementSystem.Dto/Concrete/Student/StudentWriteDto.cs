using Core.Dto;

namespace StudentManagementSystem.Dto.Concrete.Student
{
    public class StudentWriteDto : IWriteDto
    {
        public string StudentNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
