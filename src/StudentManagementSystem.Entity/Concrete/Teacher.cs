using Core.Entity;
using Core.Entity.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Entity.Concrete
{
    public class Teacher : User
    {
        public int ExpertiseId { get; set; }
        [ForeignKey("ExpertiseId")]
        public Expertise Expertise { get; set; }
    }
}
