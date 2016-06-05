namespace BlockRacer.Mvc.Rest.Requests {

    public class LoginRequest {
        public string authAccessToken { get; set; } 
        public int authProvider { get; set; }
    }

    public class CreateGameRequest {
        public int maxNrOfPlayers { get; set; }
        public int minNrOfPlayers { get; set; }
    }
    
    public class DeleteGameRequest {
        public string gameId { get; set; }
    }
}