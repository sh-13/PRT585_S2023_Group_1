using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Task_B.DBContext
{
    public class MoviesDBContext : DbContext
    {

        public MoviesDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
            base.ConfigureConventions(builder);
        }

        public DbSet<Movies> Movies { get; set; }
    }
}
