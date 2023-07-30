using System.ComponentModel.DataAnnotations;

namespace TheaterAdmin.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
