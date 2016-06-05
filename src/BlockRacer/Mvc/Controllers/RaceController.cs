using Microsoft.AspNetCore.Mvc;
using BlockRacer.Mvc.Models;
using BlockRacer.Repositories;
using BlockRacer.Repositories.Interfaces;
using BlockRacer.Configuration;
using BlockRacer.Mvc.Rest.Requests;
using BlockRacer.Mvc.Rest.Responses;

namespace BlockRacer.Mvc.Controllers
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
        public string Get() {
            return "gatter;";
        }
        
        [HttpGet("{id}")]
        public string Get(int id) {
            return "gatter:"+id;
        }
        
         // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] CreateGameRequest newGame) {
            string creatorID = "1"; //TODO, need to find ID from social media auth provider.
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
        public void Put(int id, [FromBody]string value) {
            // Step 1. Get User.
            // Step 2. Check if user are allowed to make move.
            // Validate Move.
            // Update Movement.
            // Check if all players have made their move.
            // If so, then start new round.
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] DeleteGameRequest deleteReq) {
            string authorization = this.Request.Headers["Authorization"];
            Race race = raceRepo.Find("TODO");
            
            
            if (race == null) {
                return null;
            }
            
            if (race.GetState() != Race.State.notStarted) {
                return null; // 400
            }
            raceRepo.Delete(race);
            return new OkResult();
        }
    }
}