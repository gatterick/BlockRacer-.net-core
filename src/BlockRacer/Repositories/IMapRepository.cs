using BlockRacer.Mvc.Models;
using System.Collections.Generic;

namespace BlockRacer.Repositories.Interfaces {
    public interface IMapRepository {
        Map Get(string id);
        
        bool Add(Map race);
        
        bool Delete(Map race);
        
        bool Update(Map race);
        
        IEnumerable<Map> GetAll();
    }
}