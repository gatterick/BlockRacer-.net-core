using Microsoft.AspNetCore.Mvc;
using BlockRacer.Repositories.Interfaces;
using BlockRacer.Mvc.Rest.Requests;
using BlockRacer.Mvc.Controllers.Resources;
using BlockRacer.Mvc.Models;
using Lohmann.HALight;

namespace BlockRacer.Mvc.Controllers {
    /// <summary>
    /// Contains the Controller logic for the '/map' endpoint.
    /// </summary>
    public class MapController : ControllerBase {
        
        /// <summary>The repository for the Maps</summary>
        private IMapRepository mapRepo;
        
        /// <summary>Constructor for the MapController.</summary>
        /// <param name="mapRepo">The implementation of the Map repository</param>
        public MapController(IMapRepository mapRepo) {
            this.mapRepo = mapRepo;
        }
        
        /// <summary>Callback for the GET request with an corresponding id of the '/map' endpoint.</summary>
        /// <param name="id">The id of the map to be fetched.</param>
        /// <returns> NotFound() or ObjectResult() with corresponding map information.</returns> 
        [HttpGet("{id}")]
        public IActionResult Get(string id) {
            Map map = mapRepo.Get(id);
            
            if (map == null) {
                return NotFound();
            }
            
            // Map the Domain Model to the Resource model.
            var mapResource = new MapResource {
                Id = map.Id,
                Name = map.Name,
                MapLayout = map.MapLayout  
            };
            
            //mapResource.Relations.Add(Link.CreateLink(Url.Link("UserDetailsRoute", new {id = map.Creator.Id})));
            return new OkObjectResult(mapResource);
        }
        
        /// <summary>Callback for the POST request to create a new map with corresponding JSON data</summary>
        /// <param name="newMap">JSON data mapped to the 'CreateMapRequest' data structure.</param>
        /// <returns> ObjectResult() with corresponding map information.</returns> 
        [HttpPost]
        public IActionResult Post([FromBody] CreateMapRequest newMap) {
            Player player =  (Player)this.HttpContext.Items["Player"];
            Map map = new Map(newMap.MapLayout, newMap.Name, player);
            bool addedToRepo = mapRepo.Add(map);
            if (addedToRepo) {
                MapResource mapResource = new MapResource {
                    Id = map.Id
                };
                return new ObjectResult(mapResource);
            }
            return new BadRequestResult();
        }
        
        /// <summary> Callback for POST request to delete a map. Currently not supported</summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(string id) {
            return new UnauthorizedResult();
        }
    }
}