using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
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
            // Only to be able to do some testing since either Google
            // or Facebook SDK supports .net core rc2.
            Player player = playerRepo.Find("1234");
            context.Items.Add("Player", player);
            context.Response.StatusCode = 200;
            return;

            // This is the real code...
            if (context.Request.Headers.Keys.Contains("X-Not-Authorized")) {
                context.Response.StatusCode = 401; //Unauthorized
                context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes( "{ 'error':'No Access Token provided for authentication.'}"));
                return;
            }
            
            string token = context.Request.Headers["Authorization"];
            
            if (token == "") {
                context.Response.StatusCode = 401; //Unauthorized
                context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes( "{ 'error':'No Access Token provided for authentication.'}"));
                return;                
            }

            List<Player> playerFound = playerRepo.Query();

            // Must only be One result
            if (playerFound.Count != 1) {
                // If no player found with the token Id we need to check if 
                // it's a valid Facebook token.
                context.Response.StatusCode = 401;
                context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes( "{ 'error':'Invalid Access Token.'}"));
                return;
            }

            player = playerFound[0];
            
            if (!token.StartsWith("Bearer")) {
                context.Response.StatusCode = 401; //Unauthorized
                return;            
            }

            // The token is our own created one. Let's make sure it's
            // still valid, otherwise the user needs to reauthenticate it.
            if (DateTime.Now > player.accessTokenValidUntil) {
                context.Response.StatusCode = 401;
                context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes( "{ 'error':'Access Token expired. Please login again.'}"));
                return;
            }
                        
            context.Items.Add("Player", player);
            
            await next.Invoke(context);
        }
    }
}