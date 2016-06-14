// TODO: Remvoe these in favor for the Controllers.Resources structures.
namespace BlockRacer.Mvc.Rest.Responses {   
    
    public class LoginResponse {
        public string AccessTokenToUseInFuture { get; set; }
        public string Error { get; set; }
    }
    
    public class GameStatusResponse {
        public int round { get; set; }

        public bool ongoing { get; set; }
        
        public string[] playersLeftThisTurn { get; set; }
    }
    
    public class NotAllowedResponse {
        public string message { get; set; }
    }
}