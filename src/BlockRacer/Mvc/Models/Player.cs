using System;
using System.Collections.Generic;

namespace BlockRacer.Mvc.Models {
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
        
        private string accessToken { get; set; }
        
        private DateTime accessTokenValidUntil { get; set; }
                
        private string id { get; set; }
        
        public Player(string id, int authenticationProvider) {
            this.id = id;
            this.authenticationProvider = authenticationProvider;
            userType = TypeOfUser.Freemium;
            races = new List<Race>();
        }
        
        public string GetId() {
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