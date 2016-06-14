using BlockRacer.Mvc.Models;
using BlockRacer.Repositories.Interfaces;
using System.Collections.Generic;

namespace BlockRacer.Repositories {
    ///<summary>
    /// Repository for all the ongoing and finished 
    /// race games in the game. The main purpose is to
    // store and retrieve races.
    /// <summary>
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
        
        public bool Update(Race race) {
            return true;
        }
        
        public IEnumerable<Race> Query() {
            return null;
        }
    }
}