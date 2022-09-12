using Core.Dto;

namespace StudentManagementSystem.Dto.Concrete.Grade
{
    public class GradeWriteDto : IWriteDto
    {
        public string StudentNumber { get; set; }
        public int? Exam1Value { get; set; }
        public int? Exam2Value { get; set; }
    }
}
