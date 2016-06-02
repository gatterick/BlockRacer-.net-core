using BlockRacer.Models;
using Microsoft.EntityFrameworkCore;

namespace BlockRacer {
    public class BRDbContext  : DbContext {
        public DbSet<Race> Races { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<RaceResult> RaceResults { get; set; }
            
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./blockracer.db");
        }
    }
}