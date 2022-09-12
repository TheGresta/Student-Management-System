using Core.Dto;
using StudentManagementSystem.Dto.Concrete.Student;

namespace StudentManagementSystem.Dto.Concrete.Lesson
{
    public class LessonReadDto : IReadDto
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public List<StudentReadDto> StudentList { get; set; }
    }
}
