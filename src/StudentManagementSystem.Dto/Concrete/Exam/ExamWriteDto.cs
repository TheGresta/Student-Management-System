using Core.Dto;
using StudentManagementSystem.Dto.Concrete.Grade;

namespace StudentManagementSystem.Dto.Concrete.Exam
{
    public class ExamWriteDto : IWriteDto
    {
        public int TeacherId { get; set; }
        public int LessontId { get; set; }
        public List<GradeWriteDto> StudentList { get; set; }
    }
}
