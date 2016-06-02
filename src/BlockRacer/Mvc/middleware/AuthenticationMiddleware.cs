using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace BlockRacer.Mvc.Middleware {

    public class AuthenticationMiddleware  
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)  
        {
            if (context.Request.Headers.Keys.Contains("X-Not-Authorized"))
            {
                context.Response.StatusCode = 401; //Unauthorized
                return;
            }
            
            string token = context.Request.Headers["Authorization"];
            
            if (token == null) {
                context.Response.StatusCode = 401; //Unauthorized
                return;
                
            }

            if (!token.StartsWith("Bearer")) {
                context.Response.StatusCode = 401; //Unauthorized
                return;            
            }
            
            // Validate against facebook. TODO: in future also Google.
            await _next.Invoke(context);
        }
    }
}