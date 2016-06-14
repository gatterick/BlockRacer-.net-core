using System;

namespace BlockRacer.Mvc.Models {
    ///<summary>Represents a Map used in the race.</summary>
    public class Map {
        
        public enum TileType {
            ROAD = 17,
            WALL = 18,
            OUTSIDE = 19,
            ERROR = 20
        }
        /// <summary>Unique Id identifying the map</summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Matrix describing the race track. '0' indicates
        // forbidden terrain and '1' indicates ok and '2' indicates
        /// The starting line.
        /// </summary>
        public int[,] MapLayout { get; set; }
                
        /// <summary>Name of the map</summary>
        public string Name { get; set; }
        
        /// <summary>The player who created the map.</summary>
        public Player Creator { get; set; }
        
        /// <summary>Constructor</summary>
        /// <param name="mapLayout">Layout of the Map.</param>
        /// <param name="name">Name of the map</param>
        public Map(int[,] mapLayout, string name, Player creator) {
            this.MapLayout = mapLayout;
            this.Name = name;
            this.Creator = creator;
            this.Id = Guid.NewGuid().ToString();
        }

        public TileType GetTile(int x, int y) {
            if (MapLayout[x,y].ToString() == TileType.ROAD.ToString()) {
                return TileType.ROAD;
            } else if (MapLayout[x,y].ToString() == TileType.WALL.ToString()) {
                return TileType.WALL;
            } 
            
            int width = MapLayout.GetLength(0);
            int height = MapLayout.GetLength(1);
            
            if (x < width || x > width) {
                return TileType.OUTSIDE;
            } else if (y < height || y > height) {
                return TileType.OUTSIDE;
            } else {
                return TileType.ERROR;
            }
        }
    }
    
    public class Extension {
        private int nr;
    }
}