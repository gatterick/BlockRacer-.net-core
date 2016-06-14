using Lohmann.HALight;

namespace BlockRacer.Mvc.Controllers.Resources {
    public class MapResource : Resource {
        public int[,] MapLayout { get; set; }
        
        public string Name { get; set; }
        
        public string Id { get; set; }
    }
}