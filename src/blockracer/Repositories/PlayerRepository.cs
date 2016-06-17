using BlockRacer.Mvc.Models;
using BlockRacer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BlockRacer.Repositories {
    public class PlayerRepository : IPlayerRepository {
        
        private BRDbContext db;
        
        public PlayerRepository(BRDbContext db) {
            this.db = db;
        }

        ///<summary>Find a player according to their unique id OR the access token
        /// handed out by the Login endpoint.
        /// </summary>
        /// <param name="idOrAccessToken">Unique id or access token</param>
        /// <returns>Instance of the Player</returns>
        public Player Find(long idOrAccessToken) {
            IEnumerable<Player> player = db.Players.Where(p => p.Id == idOrAccessToken).AsEnumerable(); //TODO:fix
            return null;
        }
        
        public bool Add(Player newPlayer) {
            
            using (var context = new BRDbContext())
            {
                context.Players.Add(newPlayer);
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
        
        public List<Player> Query() {
            return new List<Player>();
        }
    }
}