using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task_B.Models;

namespace Task_B.DBContext
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }

        [Column("MovieName", TypeName = "Varchar(100)")]
        public string MovieName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime ReleaseDate { get; set; }
        public string Director { get; set; }

        [Column("ContactEmailAddress", TypeName = "Nvarchar(320)")]
        public string EmailAddress { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }
    }
}
