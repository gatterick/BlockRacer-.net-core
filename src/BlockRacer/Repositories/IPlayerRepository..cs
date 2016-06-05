using BlockRacer.Mvc.Models;

namespace BlockRacer.Repositories.Interfaces {
    public interface IPlayerRepository {
        Player Find(string accessToken);
        
        bool Add(Player player);
        
        bool Delete(Player id);
        
        bool Update(Player player);
        
    }
}