using Core.Dto;

namespace StudentManagementSystem.Dto.Concrete.User
{
    public class UserReadDto : IReadDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
    }
}
