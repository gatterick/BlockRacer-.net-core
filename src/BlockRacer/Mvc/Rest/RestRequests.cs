namespace BlockRacer.Mvc.Rest.Requests {

    public class LoginRequest {
        public string authAccessToken { get; set; }
        public string authProvider { get; set; }
    }
    
    public class CreateGameRequest {
        public int maxNrOfPlayers { get; set; }
        public int minNrOfPlayers { get; set; }
    }
    
    public class DeleteGameRequest {
        public string gameId { get; set; }
    }
    
    public class GameActionRequest {
        public enum ActionType {
            FORFEIT, MOVE
        }
        
        public string gameId { get; set; }
        
        public int x { get; set; }
        
        public int y { get; set; }
        
        public ActionType type { get; set; }
    }
    
    public class GameStatusRequest {
        public string id { get; set; }
    }
    
    public class CreateMapRequest {
        public int[][] MapLayout { get; set; }
        
        public string Name { get; set; }
    }
    
    public class CreateMapResponse {
        string id;
    }
}