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
        public Teacher Teacher { get; set; }
        public List<Student> StudentList { get; set; }
        [ForeignKey("StudentList")]
        public Student Student { get; set; }
    }
}
