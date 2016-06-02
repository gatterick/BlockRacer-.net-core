using BlockRacer.Models;

namespace BlockRacer.Repositories.Interfaces {
    public interface IRaceRepository {
        Race Find(string id);
        
        bool Add(Race race);
        
        bool Delete(string id);
        
        bool Create(Race race);
        
    }
}