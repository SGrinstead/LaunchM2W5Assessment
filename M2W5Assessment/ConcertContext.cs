using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2W5Assessment
{
    public class ConcertContext : DbContext
    {
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Performer> Performers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=password123;Database=concert").UseSnakeCaseNamingConvention();
    }
}
