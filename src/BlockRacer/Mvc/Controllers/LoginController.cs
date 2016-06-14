using Microsoft.AspNetCore.Mvc;
using BlockRacer.Repositories;
using BlockRacer.Mvc.Models;
using System.Net.Http;
using System.Threading.Tasks;
using BlockRacer.Mvc.Rest.Requests;
using System;

namespace BlockRacer.Mvc.Controllers
{
    [Route("/v1/login")]
    [Controller]
    public class LoginController : ControllerBase {
        
        public enum AuthenticationProvider {
            GOOGLE = 42, FACEBOOK = 43
        }

        PlayerRepository playerRepo;
        
        public LoginController(PlayerRepository playerRepo) {
            this.playerRepo = playerRepo;
        }
        
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginRequest loginReq) {
            string tokenReq = loginReq.authAccessToken;
            
            // Validate access token against authentication provider.
            bool validToken = true; // TODO

            /* Query from the authentication provider. */
            string nickname = "gatterick"; // nicknames are unique in google and FB?, but can collide between the services themselves?
                        
            if (!validToken) {
                return new UnauthorizedResult(); // Auth. denied
            }
            /* Check if the User exists. */
            Player player = playerRepo.Find(nickname);
            
            if (player == null) {
                // first time login.
                player = new Player(nickname, "TODO", loginReq.authProvider);
            }
            
            // Is existing token valid?
            if (player.GetAccessTokenExpirationDate() > DateTime.Now) {
                // Do nothing.
                return new OkResult();
            }
            
            if (loginReq.authProvider != player.getAuthProvider()) {
                return new UnauthorizedResult(); //TODO: Find better error code Must stick with one authentication provider for now.
            }
            
            string token = loginReq.authAccessToken;
            HttpClient client = new HttpClient();
            
            string fbUrl = " https://graph.facebook.com/me?access_token=" + token;
                        
            using (HttpResponseMessage response = await client.GetAsync(fbUrl)) {
                using (HttpContent content = response.Content) {
                    string result = await content.ReadAsStringAsync();

                    if (result == null) {
                        return new UnauthorizedResult();
                    } else if (result.Contains("Invalid")) {
                        return new UnauthorizedResult();
                    } else if (result.Contains("Malformed")) {
                        return new UnauthorizedResult();
                    }
                }
            }
            
            // Generate own JWT token and return to the user.
            return new OkResult();
        }
    }
}