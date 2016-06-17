using Lohmann.HALight;

/// <summary> Resources contains the data sent as JSON
/// in the http body with a response from a valid endpoint.
/// All resources inherit the 'Resource' class to enable
/// adding HAL compatible links for content discovery.
/// </summary>
namespace BlockRacer.Mvc.Controllers.Resources {
    public class MapResource : Resource {
        public int[,] MapLayout { get; set; }
        
        public string Name { get; set; }
        
        public string Id { get; set; }
    }
}