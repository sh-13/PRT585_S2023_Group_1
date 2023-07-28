using System.ComponentModel.DataAnnotations;

namespace Task_B.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }

        public string EmailAddress { get; set; }
        public MovieLanguage Language { get; set; }
        public decimal Price { get; set; }
    }

    public enum MovieLanguage { English = 0, Japanese = 1, Hindi = 2, Chinese = 3 }
}
