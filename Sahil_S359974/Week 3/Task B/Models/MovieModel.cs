using System.ComponentModel.DataAnnotations;

namespace Task_B.Models
{
    public class MovieModel
    {
        public List<Movie> MovieList { get; set;}
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }

        public string EmailAddress { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
    }

    // public enum MovieLanguage { English = 0, Japanese = 1, Hindi = 2, Chinese = 3 }

    // public enum MovieCategory { Action = 0, Drama = 1, Horror = 2 }
}
