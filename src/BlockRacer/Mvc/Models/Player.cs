using System;
using System.Collections.Generic;

namespace BlockRacer.Mvc.Models {
    public class Player {
        public enum TypeOfUser { Freemium, Premium }
        
        private int nrOfCompletedGames { get; set; }
        
        public int nrOfDroppedGames { get; set; }
                
        private List<Race> races { get; set; }
     
        // This is probably a value taken from the public 
        // information from Facebook or Google.
        private Guid guid { get; set; }
        
        private TypeOfUser userType { get; set; }
        
        private string authenticationProvider { get; set; }
        
        private string accessToken { get; set; }
        
        private DateTime accessTokenValidUntil { get; set; }
                
        public string Id { get; set; }
        
        private string name { get; set; }
        
        public Player(string name, string id, string authenticationProvider) {
            this.name = name;
            this.Id = id;
            this.authenticationProvider = authenticationProvider;
            userType = TypeOfUser.Freemium;
            races = new List<Race>();
            accessTokenValidUntil = DateTime.Now.AddHours(24);
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
        
        public string getAuthProvider() {
            return authenticationProvider;
        }
        
        public DateTime GetAccessTokenExpirationDate() {
            return accessTokenValidUntil;
        }
    }
}