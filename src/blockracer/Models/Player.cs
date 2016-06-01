using System;
using System.Collections.Generic;

namespace BlockRacer.Models {
    public class Player {
        public enum TypeOfUser { Freemium, Premium }
        
        private int nrOfCompletedGames { get; set; }
        
        private int nrOfDroppedGames { get; set; }
                
        private List<Race> races { get; set; }
     
        // This is probably a value taken from the public 
        // information from Facebook or Google.
        private Guid guid { get; set; }
        
        private TypeOfUser userType { get; set; }
        
        private int authenticationProvider { get; set; }
        
        private int id { get; set; }
        
        public Player(int id, int authenticationProvider) {
            this.id = id;
            this.authenticationProvider = authenticationProvider;
            userType = TypeOfUser.Freemium;
            races = new List<Race>();
        }
        
        public int GetId() {
            return id;
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
        
        public int getAuthProvider() {
            return authenticationProvider;
        }
    }
}