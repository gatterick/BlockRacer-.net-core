namespace BlockRacer.RestRequests {

    public class LoginRequest {
        public string authAccessToken { get; set; } 
        public int authProvider { get; set; }
    }

    public class GameRequest {
        public int maxNrOfPlayers { get; set; }
        public int minNrOfPlayers { get; set; }
    }
}