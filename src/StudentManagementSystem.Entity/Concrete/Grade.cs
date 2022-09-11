using Core.Entity;
using Core.Entity.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Entity.Concrete
{
    public class Grade : BaseEntity
    {
        public decimal? GradeValue { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
