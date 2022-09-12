using Core.Dto;

namespace StudentManagementSystem.Dto.Concrete.Lesson
{
    public class LessonWriteDto : IWriteDto
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public List<string> StudentIdList { get; set; }
    }
}
