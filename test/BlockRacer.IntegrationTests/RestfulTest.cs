using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Xunit;
using BlockRacer;

namespace BlockRacer.IntegrationTests {
    
    public class BlockRacerIntegrationTests {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        
        public BlockRacerIntegrationTests() {
             var builder = new WebHostBuilder()
                .UseStartup<Startup>();
                
             _server = new TestServer(builder);
             _client = _server.CreateClient();
             
        }
               private async Task<string> GetAvailableGames() {
           string request = "/games";

            var response = await _client.GetAsync(request);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        [Fact]
        public async Task ReturnInstructionsGivenEmptyQueryString() {
            // Act
            var responseString = await GetAvailableGames();

            // Assert
            Assert.Equal("Pass in a number to check in the form /checkprime?5",
                responseString);
        }
    } 
    
}