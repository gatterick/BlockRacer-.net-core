using BlockRacer.Mvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlockRacer.Repositories.Interfaces {
    public class MapRepository : IMapRepository {
        
        private BRDbContext db; 
        public MapRepository(BRDbContext db) {
            this.db = db;
        }
        public Map Get(string id) {
            return null;
        }
        
        /// <summary> Adds a map to the repository.</summary>
        /// <param name="map">The instance of Map to be saved.</param>
        /// <returns> true if map was saved in repository otherwise false</returns>
        public bool Add(Map map) {
            using (var context = new BRDbContext())
            {
                context.Maps.Add(map);
                int nrOfEntriesWritten = context.SaveChanges();
                if (nrOfEntriesWritten == 1) {
                    return true;
                }
            }

            return false;
        }
        
        public bool Delete(Map race) {
            return false;
        }
        
        
        public bool Update(Map race) {
            return false;
        }
        
        public IEnumerable<Map> GetAll() {
            return null;
        }
    }
}