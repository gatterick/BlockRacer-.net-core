using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using System.Text;
using Newtonsoft.Json;
using BlockRacer.Mvc.Rest.Requests;
using BlockRacer.Configuration;
using BlockRacer.Mvc.Models;
/// <Summary>
/// Base class for all Integration endpoint-tests. By
/// inheriting and calling the base constructor the BlockRacer
/// server is:
/// 1 Initialized and started.
/// 2. A client to the webserver is started.
/// 3. A fake user is created and saved in the database for 
/// use with the REST api calls.
/// </summary> 
namespace BlockRacer.IntegrationTests.Base {
    public class BaseTestSetup {
        /// <summary>
        /// Prepares the Test Setup
        protected readonly TestServer server;

        protected readonly HttpClient client;
        
        protected Player dummyPlayer;

        public BaseTestSetup() {
             var builder = new WebHostBuilder()
                .UseStartup<Startup>();
                
            //this.CreateUserInDatabase();

             server = new TestServer(builder);
             client = server.CreateClient();
             
             client.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", "Your Oauth token");
        }
/*
        private void CreateUserInDatabase() {
            Player dummyPlayer = new Player("gatterick", 1234, "Facebook");
            dummyPlayer.accessToken = "DummyAccessToken";
            dummyPlayer.accessTokenValidUntil = DateTime.Now.AddHours(1);
            using (var context = new BRDbContext())
            {
                context.Players.Add(dummyPlayer);
                context.SaveChanges();
            }
        }
        private async Task<string> GetAvailableGames(string game) {
            RequestBuilder req = server.CreateRequest("v1/races");
            
            if (game != "") {
                game = "/" + game;
            }
           string request = "v1/races"+game;

            var response = await client.GetAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
        
        private async Task<string> Login() {
            string request = "v1/login";
           
           var requestData = new LoginRequest() {
               authAccessToken = "43",
               authProvider = "Facebook"
           };
           
           string json = JsonConvert.SerializeObject(requestData).ToString();
            var sc = new StringContent(json, 
                Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync(request,  sc);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();            
        }
        private async Task<string> CreateGame() {
            string request = "v1/races";
           
           var requestData = new CreateGameRequest() {
               minNrOfPlayers = 2,
               maxNrOfPlayers = 2
           };
           
           string a = JsonConvert.SerializeObject(requestData).ToString();
            var sc = new StringContent(a,
                Encoding.UTF8, "application/json");
                            
            var response = await this.client.PostAsync(request,  sc);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }*/
    }
}