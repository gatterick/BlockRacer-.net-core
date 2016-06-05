using BlockRacer.Mvc.Models;

namespace BlockRacer.Repositories.Interfaces {
    public interface IRaceRepository {
        Race Find(string id);
        
        bool Add(Race race);
        
        bool Delete(Race race);
        
        bool Create(Race race);
        
    }
}