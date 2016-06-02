namespace BlockRacer.Models {
    public class Map {
        private int[,] map { get; set; }
        
        public Map(int[,] map) {
            this.map = map;
        }
        
        public int[,] getMap() {
            return map;
        }
    }
    
    public class Extension {
        private char symbol;
    }
}