using BlockRacer.Mvc.Models;
using System.Collections.Generic;

namespace BlockRacer.Repositories.Interfaces {
    public interface IRaceRepository {
        Race Find(string id);
        
        bool Add(Race race);
        
        bool Delete(Race race);
        
        bool Update(Race race);
        
        List<Race> Query();
    }
}