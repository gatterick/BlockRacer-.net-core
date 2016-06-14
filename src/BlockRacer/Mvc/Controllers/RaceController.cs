using Microsoft.AspNetCore.Mvc;
using BlockRacer.Mvc.Models;
using BlockRacer.Repositories.Interfaces;
using BlockRacer.Configuration;
using BlockRacer.Mvc.Rest.Requests;
using BlockRacer.Mvc.Rest.Responses;

using System.Collections.Generic;

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
        public IActionResult Get() {
            IEnumerable<Race> races = raceRepo.Query(); //TODO: LINQ?
            return new ObjectResult(races);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(string id) {
            
            Race race = raceRepo.Find(id);
            
            if (race == null) {
                return new NotFoundResult();
            }
            
            return new ObjectResult(race);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] CreateGameRequest newGame) {
            Player player = (Player)HttpContext.Items["Player"];

            int nrOfOngoingGames = player.GetNrOfOngoingGames();
            int nrofAllowedGames = 0;
            IConfiguration config =  Config.GetConfiguration(player);
            
            int nrOfAllowedGames = config.GetMaxNrOfParalellGames();
            
            if (player.GetNrOfOngoingGames() > nrofAllowedGames) {
                return new OkResult();// 400 not allowed operation
            }

            Race newRace = new Race(newGame.minNrOfPlayers,
                                    newGame.maxNrOfPlayers,
                                    player);
            
            bool opOk = raceRepo.Add(newRace);
            return new ObjectResult(null); //TODO.
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]GameActionRequest gameUpdateRequest) {
            Player player = (Player)HttpContext.Items["Player"];
            
            Race race = raceRepo.Find(gameUpdateRequest.gameId);
            
            if (race == null) {
                return new NotFoundResult();
            }
            
            GameActionRequest.ActionType type = gameUpdateRequest.type;
            
            if (type == GameActionRequest.ActionType.FORFEIT) {
                bool result = race.Remove(player);
                if (result == true) {
                    player.nrOfDroppedGames++; // Bad for reputation.
                    return new OkResult();
                }
                return new BadRequestResult();
            } else if (type == GameActionRequest.ActionType.MOVE) {
                int newX = gameUpdateRequest.x;
                int newY = gameUpdateRequest.y;
                // Check if user are allowed to make move.
                bool allowed = race.UpdatePlayer(player, newX, newY);
                if (allowed == true) {
                    return new OkResult();
                }
                return new BadRequestResult();
            }
            return new OkResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody] DeleteGameRequest deleteReq) {
            Player player = (Player)HttpContext.Items["Player"];

            NotAllowedResponse na = new NotAllowedResponse();
            BadRequestObjectResult res = new BadRequestObjectResult(na);
            res.StatusCode = 400; // TODO, find correct HTTP resp. code

            Race race = raceRepo.Find(deleteReq.gameId);
            if (race == null) {
                na.message = "No such race with id '" + deleteReq.gameId + "' exists.";
            }

            if (!race.getOwner().Equals(player)) {
                na.message = "You're not the owner of this race.";
            }
            
            if (race.GetState() != Race.State.notStarted) {
                na.message = "You can't delete a game in progress.";
            }

            bool deletionOk = raceRepo.Delete(race);
            
            if (!deletionOk) {
                // TODO, Internal 500?
            }

            if (na.message != "") {
                return res;
            }
            
            return new OkResult();
        }
    }
}