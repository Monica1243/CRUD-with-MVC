namespace Ecommerce.Models.DTO
{
    public class UserDetailsDTO
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public bool? MembershipType { get; set; }

        public string Role { get; set; } = null!;

        public string? Address { get; set; }

        public string Phone { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime ModifiedAt { get; set; }

    }
}
