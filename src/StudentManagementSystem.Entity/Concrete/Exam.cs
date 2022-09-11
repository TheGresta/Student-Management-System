using Core.Entity;
using Core.Entity.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Entity.Concrete
{
    public class Exam : BaseEntity
    {
        public int? Exam1 { get; set; }
        public int? Exam2 { get; set; }
        public decimal? Avg { get; set; }
        public string? LetterGrade { get; set; }
        public bool? IsPassed { get; set; }
        public int LessontId { get; set; }
        [ForeignKey("LessontId")]
        public Lesson Lesson { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
