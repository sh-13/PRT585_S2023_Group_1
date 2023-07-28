using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task_B.Models;

namespace Task_B.Data
{
    public class Task_BContext : DbContext
    {
        public Task_BContext (DbContextOptions<Task_BContext> options)
            : base(options)
        {
        }

        public DbSet<Task_B.Models.Movie> Movie { get; set; } = default!;
    }
}
