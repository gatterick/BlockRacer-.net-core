// TODO: Remvoe these in favor for the Controllers.Resources structures.
namespace BlockRacer.Mvc.Rest.Responses {   
    
    public class LoginResponse {
        public string AccessTokenToUseInFuture { get; set; }
        public string Error { get; set; }
    }
    
    public class NotAllowedResponse {
        public string message { get; set; }
    }
}