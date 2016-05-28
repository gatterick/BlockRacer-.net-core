using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BlockRacer.Models;
using BlockRacer.Repositories;
using System.Threading.Tasks;
using BlockRacer.Configuration;


namespace BlockRacer.Controllers
{
    [Route("/v1/races")]
    [Controller]
    public class RaceController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "gatter;";
        }
        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "gatter:"+id;
        }
        
         // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] GameRequest newGame)
        {   
            string creatorID = newGame.creatorID;
            
            Player player = PlayerRepository.Find(creatorID);
            
            int nrOfOngoingGames = player.GetNrOfOngoingGames();
            int nrofAllowedGames = 0;
            IConfiguration config =  Config.GetConfiguration(player);
            
            int nrOfAllowedGames = config.GetMaxNrOfParalellGames();
            
            if (player.GetNrOfOngoingGames() > nrofAllowedGames){
                return new OkResult();// 400 not allowed operation
            }

            Race newRace = new Race(newGame.minNrOfPlayers,
                                    newGame.maxNrOfPlayers,
                                    player);
                                    
            bool opOk = RaceRepository.Add(newRace);
            return new OkResult();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string guid)
        {
        }
    }
    
    public class GameRequest {
        public string creatorID { get; set; }
        public int maxNrOfPlayers { get; set; }
        public int minNrOfPlayers { get; set; }
        
        override
        public string ToString() {
            return minNrOfPlayers + "," + maxNrOfPlayers + "," + creatorID;
        }
    }
}