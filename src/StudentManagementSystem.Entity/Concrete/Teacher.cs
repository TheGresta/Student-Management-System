using Core.Entity;
using Core.Entity.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Entity.Concrete
{
    public class Teacher : BaseEntity
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int ExpertiseId { get; set; }
        [ForeignKey("ExpertiseId")]
        public Expertise Expertise { get; set; }

    }
}
