using System.ComponentModel.DataAnnotations;

namespace TheaterAdmin.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public enum Language
        {
            English,
            Japanese,
            Chinese
        }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
