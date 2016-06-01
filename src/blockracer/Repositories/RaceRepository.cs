using BlockRacer.Models;
using BlockRacer;

namespace BlockRacer.Repositories {
    public class RaceRepository {
        
        BRDbContext db;
        
        public RaceRepository(BRDbContext db) {
            this.db = db;
        }
        public Race Find(string id) {
            return null;
        }
        
        public bool Add(Race race) {
            return true;
        }
        
        public bool Delete(string id) {
            return true;
        }
        
        public bool Create(Race race) {
            return true;
        }
    }
}