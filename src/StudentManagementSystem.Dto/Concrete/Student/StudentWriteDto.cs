using Core.Dto;

namespace StudentManagementSystem.Dto.Concrete.Student
{
    public class StudentWriteDto : IWriteDto
    {
        public int UserId { get; set; }
        public string StudentNumber { get; set; }
    }
}
