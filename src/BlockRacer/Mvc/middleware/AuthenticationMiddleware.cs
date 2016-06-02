using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net.Http;

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
            
            HttpClient client = new HttpClient();
            
            string fbUrl = " https://graph.facebook.com/me?access_token=" + token;
                        
            using (HttpResponseMessage response = await client.GetAsync(fbUrl)) {
                using (HttpContent content = response.Content)
            	{
                    // ... Read the string.
                    string result = await content.ReadAsStringAsync();

                    // ... Display the result.
                    if (result == null) {
                        context.Response.StatusCode = 401; //Unauthorized
                        return;
                    }
                    
                    System.Console.WriteLine(result);
                    System.Console.WriteLine(result.Contains("Invalid"));
                    if (result.Contains("Invalid")) {
                        context.Response.StatusCode = 401; //Unauthorized
                        return;                       
                    }
                    else if (result.Contains("Malformed")) {
                        context.Response.StatusCode = 401; //Unauthorized
                        return;                       
                    }
                }
            }
            // Validate against facebook. TODO: in future also Google.
            await _next.Invoke(context);
        }
    }
}