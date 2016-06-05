using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net.Http;

using BlockRacer.Mvc.Models;
using BlockRacer.Repositories.Interfaces;

namespace BlockRacer.Mvc.Middleware {
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate next;

        private readonly IPlayerRepository playerRepo;
        
        public AuthenticationMiddleware(RequestDelegate next,
                                        IPlayerRepository playerRepo) {
            this.next = next;
            this.playerRepo = playerRepo;
        }
        
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.Keys.Contains("X-Not-Authorized"))
            {
                context.Response.StatusCode = 401; //Unauthorized
                return;
            }
            
            string token = context.Request.Headers["Authorization"];
            
            // First check if it's a 'local token'. i.e. one that we
            // have given out earlier and if it's still valid.
            Player player = playerRepo.Find(token);
            
            if (player == null) {
                // This is a facebook token since we don't save these in
                // the database, only our own created ones. Let's validate this 
                // one and continue by handing out our own token.
            } else {
                // The token is our own created one. Let's make sure it's
                // still valid, otherwise the user needs to reauthenticate it.
            }
            
            
            
            if (token == null) {
                context.Response.StatusCode = 401; //Unauthorized
                return;
                
            }

            if (!token.StartsWith("Bearer")) {
                context.Response.StatusCode = 401; //Unauthorized
                return;            
            }
            
            HttpClient client = new HttpClient();
            
            string fbUrl = " https://graph.facebook.com/me?access_token=" + token;
                        
            using (HttpResponseMessage response = await client.GetAsync(fbUrl)) {
                using (HttpContent content = response.Content)
            	{
                    string result = await content.ReadAsStringAsync();

                    if (result == null) {
                        context.Response.StatusCode = 401;
                        return;
                    } else if (result.Contains("Invalid")) {
                        context.Response.StatusCode = 401;
                        return;                       
                    } else if (result.Contains("Malformed")) {
                        context.Response.StatusCode = 401;
                        return;                       
                    }
                }
            }
            
            context.Items.Add("Player", player);
            
            await next.Invoke(context);
        }
    }
}