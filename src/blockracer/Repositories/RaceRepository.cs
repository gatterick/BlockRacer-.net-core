using BlockRacer.Mvc.Models;
using BlockRacer.Repositories.Interfaces;

namespace BlockRacer.Repositories {
    public class RaceRepository : IRaceRepository {
        
        public BRDbContext db { get; set; }
        
        public RaceRepository(BRDbContext db) {
            this.db = db;
        }
        public Race Find(string id) {
            return null;
        }
        
        public bool Add(Race race) {
            return true;
        }
        
        public bool Delete(Race race) {
            return true;
        }
        
        public bool Create(Race race) {
            return true;
        }
    }
}