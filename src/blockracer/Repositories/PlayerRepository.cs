using BlockRacer.Models;
using BlockRacer.Repositories.Interfaces;

namespace BlockRacer.Repositories {
    public class PlayerRepository : IPlayerRepository {
        public Player Find(int player) {
            return null;
        }
        
        public bool Add(Player newPlayer) {
            
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