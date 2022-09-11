using Core.Dto;

namespace StudentManagementSystem.Dto.Concrete.Teacher
{
    public class TeacherWriteDto : IWriteDto
    {
        public int UserId { get; set; }
        public int ExpertiseId { get; set; }
    }
}
