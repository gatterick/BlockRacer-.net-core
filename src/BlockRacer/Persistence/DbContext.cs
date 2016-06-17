using BlockRacer.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace BlockRacer {
    public class BRDbContext  : DbContext {
        public DbSet<Race> Races { get; set; }
        
        public DbSet<Map> Maps { get; set; }
        
        public DbSet<Player> Players { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<RaceResult> RaceResults { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=/Users/gatterick/projects/blockracer2.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Map>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Race>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<RaceResult>()
                .HasKey(rr => rr.Id);

             modelBuilder.Entity<PlayerResult>()
                .HasKey(rr => rr.Id);

           modelBuilder.Entity<Event>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Car>()
                .HasKey(c => c.Id);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}