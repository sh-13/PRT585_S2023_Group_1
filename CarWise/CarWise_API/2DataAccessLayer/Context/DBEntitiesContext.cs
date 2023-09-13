using _2DataAccessLayer.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace _2DataAccessLayer.Context
{   

    public class DBEntitiesContext : DbContext
    {
        public DBEntitiesContext(DbContextOptions<DBEntitiesContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<User> Users { get; set; }

    }

}
