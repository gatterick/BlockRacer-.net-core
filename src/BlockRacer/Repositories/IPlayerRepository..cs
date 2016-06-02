using BlockRacer.Models;

namespace BlockRacer.Repositories.Interfaces {
    public interface IPlayerRepository {
        Player Find(int id);
        
        bool Add(Player player);
        
        bool Delete(Player id);
        
        bool Update(Player race);
        
    }
}