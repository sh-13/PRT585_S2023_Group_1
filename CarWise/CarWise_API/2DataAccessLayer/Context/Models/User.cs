using System.ComponentModel.DataAnnotations;

namespace _2DataAccessLayer.Context.Models
{
    public class User
    {
        [Key]
        [Required]
        [EmailAddress]
        [MaxLength(255)]  // Ensuring the email fits within standard lengths
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }  // This should store a hashed version of the password, never plain text.

        [Required]
        [MaxLength(50)]  // You can specify the maximum length based on your database column definition.
        public string UserFirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserLastName { get; set; }
    }
}
