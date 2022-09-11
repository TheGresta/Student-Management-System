using Core.Dto;

namespace StudentManagementSystem.Dto.Concrete.Lesson
{
    public class LessonWriteDto : IWriteDto
    {
        public int TeacherId { get; set; }
        public List<int> StudentIdList { get; set; }
    }
}
