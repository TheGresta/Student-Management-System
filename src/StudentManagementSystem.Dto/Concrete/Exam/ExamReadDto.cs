using Core.Dto;
using StudentManagementSystem.Dto.Concrete.Grade;

namespace StudentManagementSystem.Dto.Concrete.Exam
{
    public class ExamReadDto : IReadDto
    {
        public int Id { get; set; }
        public string LessonId { get; set; }
        public string TeacherId { get; set; }
        public List<GradeReadDto> StudentList { get; set; }
    }
}
