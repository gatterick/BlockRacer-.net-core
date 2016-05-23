using System;
using System.Collections.Generic;

namespace BlockRacer.Models {
    public class Player {
        public enum TypeOfUser { Freemium, Premium }
        
        private int nrOfCompletedGames { get; set; }
        
        private int nrOfDroppedGames { get; set; }
                
        private List<Race> races { get; set; }
        
        private string name { get; set; }
        
        private Guid guid { get; set; }
        
        private TypeOfUser userType { get; set; }
        
        public Player() {
            userType = TypeOfUser.Freemium;
            races = new List<Race>();
        }
        
        public List<Race> GetOngoingGames() {
            return races;
        }

        public int GetNrOfOngoingGames() {
            return races.Count;
        }
        
        public TypeOfUser getUserType() {
            return userType;
        }
    }
}