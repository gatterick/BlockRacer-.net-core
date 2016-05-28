using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using System.Text;
using Newtonsoft.Json;

namespace BlockRacer.IntegrationTests {
    
    
    public class GameRequest {
        public string creatorID { get; set; }
        public int maxNrOfPlayers { get; set; }
        public int minNrOfPlayers { get; set; }
    }
    
    public class BlockRacerIntegrationTests {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public BlockRacerIntegrationTests() {
             var builder = new WebHostBuilder()
                .UseStartup<Startup>();
                
             _server = new TestServer(builder);
             _client = _server.CreateClient();
             
        }

        private async Task<string> GetAvailableGames(string game) {
            RequestBuilder req = _server.CreateRequest("v1/races");
            
            if (game != "") {
                game = "/" + game;
            }
           string request = "v1/races"+game;

            var response = await _client.GetAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
        
        private async Task<string> CreateGame() {
            string request = "v1/races";
           
           var requestData = new GameRequest() {
               creatorID = "kalle",
               minNrOfPlayers = 2,
               maxNrOfPlayers = 2
           };
           
           string a = JsonConvert.SerializeObject(requestData).ToString();
            var sc = new StringContent(a, 
                Encoding.UTF8, "application/json");
            
    
            var response = await _client.PostAsync(request,  sc);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
        
        [Fact]
        public async Task TestUseCase1() {
            // Act
            var responseString = await CreateGame();
            Console.WriteLine(responseString);
        }
        
        //[Fact]
        public async Task TestGetAvailableGames2() {
            // Act
            var responseString = await GetAvailableGames("12345");
            
            Console.WriteLine(responseString);
        }

    } 
    
}