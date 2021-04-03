using System;
using System.ComponentModel.DataAnnotations;

namespace Test.data.Models
{
    public class User
    {
        [Key, Required]
        public int Id { get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "Email can't be empty")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        public string ProfilePic { get; set; }

        public bool? IsActive { get; set; } = true;

        public string HashCode { get; set; }

        public bool IsClientUser { get; set; }

    }
}
