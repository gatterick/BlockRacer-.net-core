using System;
using System.Collections.Generic;

namespace BlockRacer.Mvc.Models {
    public class Player {
        public enum TypeOfUser { Freemium, Premium }
        
        public int nrOfCompletedGames { get; set; }
        
        public int nrOfDroppedGames { get; set; }
                
        public List<Race> races { get; set; }
     
        public TypeOfUser userType { get; set; }
        
        public string authenticationProvider { get; set; }
        
        public string accessToken { get; set; }
        
        public DateTime accessTokenValidUntil { get; set; }
                
        public long Id { get; set; }
        
        private string name { get; set; }
        
        public Player(string name, long id, string authenticationProvider) {
            this.name = name;
            this.Id = id;
            this.authenticationProvider = authenticationProvider;
            userType = TypeOfUser.Freemium;
            races = new List<Race>();
            accessTokenValidUntil = DateTime.Now.AddHours(24);
        }
    }
}