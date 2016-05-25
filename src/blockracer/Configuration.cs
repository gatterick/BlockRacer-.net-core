using BlockRacer.Models;

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
}