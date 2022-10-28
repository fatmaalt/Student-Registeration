using System.ComponentModel.DataAnnotations;

namespace student_registration.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
         public string Email { get; set; }
        public List<Studentt>? Students { get; set; }
      [Required]
         public string Role { get; set; }

    }
}