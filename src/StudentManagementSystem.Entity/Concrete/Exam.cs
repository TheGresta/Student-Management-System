using Core.Entity;
using Core.Entity.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Entity.Concrete
{
    public class Exam : BaseEntity
    {
        public int LessontId { get; set; }
        [ForeignKey("LessontId")]
        public Lesson Lesson { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
        public List<Grade> StudentList { get; set; }
        [ForeignKey("StudentList")]
        public Grade Grade { get; set; }
    }
}
