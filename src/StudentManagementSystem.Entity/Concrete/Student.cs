using Core.Entity;
using Core.Entity.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Entity.Concrete
{
    public class Student : BaseEntity
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Number { get; set; }
        [ForeignKey("Number")]
        public StudentNumber StudentNumber { get; set; }
        public decimal GradeValue { get; set; }
        [ForeignKey("GradeValue")]
        public Grade Grade { get; set; }
    }
}
