using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using BlockRacer.Models;
using BlockRacer.Repositories;
using BlockRacer.Configuration;

namespace BlockRacer.Controllers
{
    public class RaceController : ControllerBase
    {
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string guid)
        {
            return "value";
        }
        
         // POST api/values
        [HttpPost]
        public void createRace([FromBody]string json)
        {
            CreateGameJsonRequest newGame = 
                JsonConvert.DeserializeObject<CreateGameJsonRequest>(json);

            string creatorID = newGame.creatorID;
            
            Player player = PlayerRepository.getPlayer(creatorID);
            
            int nrOfOngoingGames = player.GetNrOfOngoingGames();
            int nrofAllowedGames = 0;
            IConfiguration config =  Config.GetConfiguration(player);
            
            int nrOfAllowedGames = config.GetMaxNrOfParalellGames();
            
            if (player.GetNrOfOngoingGames() > nrofAllowedGames){
                return;// 400 not allowed operation
            }

            Race newRace = new Race(newGame.minNrOfPlayers,
                                    newGame.maxNrOfPlayers,
                                    player);
                                    
            bool opOk = RaceRepository.Create(newRace);
            
        }

         // POST api/values
        [HttpPost("{id}")]
        public void updateGame([FromBody]string value)
        {
            
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
    
    class CreateGameJsonRequest {
        public string creatorID;
        public int maxNrOfPlayers;
        public int minNrOfPlayers;
    }
}