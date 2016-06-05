namespace BlockRacer.Mvc.Rest.Responses {   
    public class LoginResponse {
        public string AccessTokenToUseInFuture { get; set; }
        public string Error { get; set; }
    }
}