using System;
using System.Collections.Generic;

namespace BlockRacer.Mvc.Models {
    public class RaceResult {
        public Player creator { get; set; }
        
        public Guid raceGuid { get; set; }
        
        public string Id { get; set; }

        public List<PlayerResult> result { get; set; }
        
    }
    
    public class PlayerResult {
        public string Id { get; set; }
        public int nrOfTurns { get; set; }
        
        public int position { get; set; }
        
        public Player player { get; set; }
    }
}