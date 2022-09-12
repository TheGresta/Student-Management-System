using Core.Entity;
using Core.Entity.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Entity.Concrete
{
    public class Student : User
    {
        public string StudentNo { get; set; }
        public decimal GradeValue { get; set; }
        [ForeignKey("GradeValue")]
        public Grade Grade { get; set; }
    }
}
