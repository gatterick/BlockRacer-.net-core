using BlockRacer.Mvc.Models;
using BlockRacer.Repositories.Interfaces;
using System.Collections.Generic;

namespace BlockRacer.Repositories {
    public class PlayerRepository : IPlayerRepository {
        
        private BRDbContext db;
        
        public PlayerRepository(BRDbContext db) {
            this.db = db;
        }

        public Player Find(string id) {
            return null;
        }
        
        public bool Add(Player newPlayer) {
            
            Player player = Find(newPlayer.Id);
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
        
        public List<Player> Query(string query) {
            return new List<Player>();
        }
    }
}