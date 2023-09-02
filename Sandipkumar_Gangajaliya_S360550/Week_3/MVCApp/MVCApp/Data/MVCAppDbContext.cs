using MVCApp.Model;
using Microsoft.EntityFrameworkCore;

namespace MVCApp.Data
{
    public class MVCAppDbContext: DbContext
    {
        public MVCAppDbContext(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Person> Person { get; set; }
    }
}
