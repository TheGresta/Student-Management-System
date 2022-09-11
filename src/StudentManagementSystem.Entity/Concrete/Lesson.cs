using Core.Entity;
using Core.Entity.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Entity.Concrete
{
    public class Lesson : BaseEntity
    {
        public string Name { get; set; }
        public int TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public User User { get; set; }
        public List<StudentNumber> StudentNumberList { get; set; }
        [ForeignKey("StudentNumberList")]
        public StudentNumber StudentNumber { get; set; }
    }
}
