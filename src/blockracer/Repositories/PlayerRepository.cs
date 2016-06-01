using BlockRacer.Models;

namespace BlockRacer.Repositories {
    public class PlayerRepository {
        public Player Find(int playerID) {
            return null;
        }
        
        public bool Create(Player newPlayer) {
            
            Player player = Find(newPlayer.GetId());
            using (var context = new BRDbContext())
            {
                context.Players.Add(player);
                context.SaveChanges();
            }
            return true;
        }
        
        public bool Delete(Player player) {
            return true;
        }
        
        public bool Update(Player player) {
            return true;
        }
    }
}