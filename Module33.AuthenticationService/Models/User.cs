using System;

namespace Module33.AuthenticationService.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        // public int RoleId { get; set; }
    }
}
