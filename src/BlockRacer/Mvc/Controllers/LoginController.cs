using Microsoft.AspNetCore.Mvc;
using BlockRacer.Repositories;
using BlockRacer.Models;

using BlockRacer.RestRequests;
using BlockRacer.RestResponses;

namespace BlockRacer.Controllers
{
    [Route("/v1/login")]
    [Controller]
    public class LoginController {
        
        public enum AuthenticationProvider {
            GOOGLE = 42, FACEBOOK = 43
        }

        PlayerRepository playerRepo;
        
        public LoginController(PlayerRepository playerRepo) {
            this.playerRepo = playerRepo;
        }
        
        [HttpPost]
        public IActionResult Login([FromBody]LoginRequest loginReq) {
            /* Query from the authentication provider. */
            int nickname = 0; // nicknames are unique in google and FB, but can collide between the services themselves?
            
            // Validate access token against authentication provider.
            bool validToken = true; // TODO
            
            if (!validToken) {
                return new UnauthorizedResult(); // auth denied.
            }
            /* Check if the User exists. */
            Player player = playerRepo.Find(nickname);
            
            if (player == null) {
                // first time login.
                player = new Player(nickname, loginReq.authProvider);
            }
            
            if (loginReq.authProvider != player.getAuthProvider()) {
                return new UnauthorizedResult(); //TODO: Find better error code Must stick with one authentication provider for now.
            }
            
            // Generate own JWT token and return to the user.
            return new OkResult();
        }
    }
}