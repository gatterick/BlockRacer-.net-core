using BlockRacer.Models;
using Microsoft.EntityFrameworkCore;

namespace BlockRacer.Configuration {
    
    public interface IConfiguration {
        int GetMaxNrOfParalellGames();
    }
    
    public class Freemium : IConfiguration {
        
        public int GetMaxNrOfParalellGames() {
            return 3;
        }
    }
    
    public class Premium : IConfiguration {
        public int GetMaxNrOfParalellGames() {
            return 50;
        }
    }
    
    public static class Config {
        public static IConfiguration GetConfiguration(Player player) {
            IConfiguration config = null;
            if (player.getUserType() == Player.TypeOfUser.Freemium) {
                config = new Freemium();
            } else if (player.getUserType() == Player.TypeOfUser.Premium) {
                config = new Premium();
            } else {
                // assert here, causing a 500.
            }
            return config;
        }
    }
    
    public class BlockRacerContext : DbContext {
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