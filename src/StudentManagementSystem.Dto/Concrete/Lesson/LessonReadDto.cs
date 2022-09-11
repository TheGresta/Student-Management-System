using Core.Dto;
using StudentManagementSystem.Entity.Concrete;

namespace StudentManagementSystem.Dto.Concrete.Lesson
{
    public class LessonReadDto : IReadDto
    {
        public int Id { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> StudentList { get; set; }
    }
}
