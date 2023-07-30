using Microsoft.EntityFrameworkCore;

namespace Task_B.DBContext
{
    public class MoviesDBContext : DbContext
    {

        public MoviesDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movies> Movies { get; set; }
    }
}
