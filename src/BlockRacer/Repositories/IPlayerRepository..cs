using BlockRacer.Mvc.Models;
using System.Collections.Generic;

namespace BlockRacer.Repositories.Interfaces {
    public interface IPlayerRepository {
        Player Find(string accessToken);
        
        bool Add(Player player);
        
        bool Delete(Player id);
        
        bool Update(Player player);
        
        List<Player> Query(string query);
    }
}