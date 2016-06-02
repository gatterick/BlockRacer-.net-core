using Microsoft.AspNetCore.Mvc;
using BlockRacer.Models;
using BlockRacer.Repositories;
using BlockRacer.Repositories.Interfaces;
using BlockRacer.Configuration;
using BlockRacer.RestRequests;

namespace BlockRacer.Controllers
{
    [Route("/v1/races")]
    [Controller]
    public class RaceController : ControllerBase
    {
        IPlayerRepository playerRepo;
        
        IRaceRepository raceRepo;
        
        public RaceController(IPlayerRepository playerRepo,
                              IRaceRepository raceRepo) {
            this.playerRepo = playerRepo;
            this.raceRepo = raceRepo;
        }
        
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
            int creatorID = 1; //TODO, need to find ID from social media auth provider.
            Player player = playerRepo.Find(creatorID);
            
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
            System.Console.WriteLine(raceRepo);
            bool opOk = raceRepo.Create(newRace);
            return new OkResult();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            Race race = raceRepo.Find(id);
            
            if (race.GetState() != Race.State.notStarted) {
                return; // 400
            }            
        }
    }
}