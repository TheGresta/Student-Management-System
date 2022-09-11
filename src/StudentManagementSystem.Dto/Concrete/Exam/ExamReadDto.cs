using Core.Dto;
using StudentManagementSystem.Dto.Concrete.Grade;

namespace StudentManagementSystem.Dto.Concrete.Exam
{
    public class ExamReadDto : IReadDto
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string TeacherId { get; set; }
        public int Exam1 { get; set; }
        public int Exam2 { get; set; }
        public decimal Avg { get; set; }
        public string LetterGrade { get; set; }
        public string IsPassed { get; set; }
    }
}
