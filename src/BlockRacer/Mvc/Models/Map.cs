using System;
using System.Collections.Generic;

namespace BlockRacer.Mvc.Models {
    ///<summary>Represents a Map used in the race.</summary>
    public class Map {
        
        /// <summary>Unique Id identifying the map</summary>
        public string Id { get; set; }
        
        /// <summary>
        /// Matrix describing the race track. '0' indicates
        // forbidden terrain and '1' indicates ok and '2' indicates
        /// The starting line.
        /// </summary>
        public List<TileType> MapLayout { get; set; }
        public int MapRows { get; set; }
        public int MapColumns { get; set; }
        /// <summary>Name of the map</summary>
        public string Name { get; set; }
        
        /// <summary>The player who created the map.</summary>
        public Player Creator { get; set; }
        
        /// <summary>Constructor</summary>
        /// <param name="mapLayout">Layout of the Map.</param>
        /// <param name="name">Name of the map</param>
        public Map(int[][] mapLayout, string name, Player creator) {
            this.MapColumns = mapLayout.GetLength(0);
            this.MapRows = mapLayout.GetLength(1);
            this.MapLayout = new List<TileType>();

            for (int i = 0; i <  mapLayout.GetLength(0); i++) {
                for (int j = 0; j <  mapLayout.GetLength(1); j++) {
                    this.MapLayout.Add(new TileType(mapLayout[i][j]));
                }
            }
            this.Name = name;
            this.Creator = creator;
            this.Id = Guid.NewGuid().ToString();
        }

        public int[,] GetMapAsMatrix() {
            int[,] map = new int[MapRows, MapColumns];

            for (int i = 0; i <  MapRows; i++) {
                for (int j = 0; j <  MapColumns; j++) {
                    map[i,j] = MapLayout[i + j].GetIntFromType();
                }
            }
            return map;
        }

        public TileType.Tile GetTile(int x, int y) {
            if (x < MapColumns || x > MapColumns) {
                return TileType.Tile.OUTSIDE;
            } else if (y < MapRows || y > MapRows) {
                return TileType.Tile.OUTSIDE;
            }
            return MapLayout[x * MapColumns + y].tileType;

        }
    }
    
    public class TileType {
        public string Id { get; set; }
        public enum Tile {
            ROAD = 17,
            WALL = 18,
            OUTSIDE = 19,
            ERROR = 20
        }

        public Tile GetTypeFromInt(int nr) {
            switch (nr) {
                case 17:
                    return Tile.ROAD;
                case 18:
                    return Tile.WALL;
                case 19:
                    return Tile.OUTSIDE;
                default:
                    return Tile.ERROR;
            }
        }

        public int GetIntFromType() {
            switch (tileType) {
                case Tile.ROAD:
                    return 17;
                case Tile.WALL:
                    return 18;
                case Tile.OUTSIDE:
                    return 19;
                default:
                    return 20;
            }
        }
        public Tile tileType { get; set; }

        public TileType(int tileInt) {
            tileType = GetTypeFromInt(tileInt);
        }
    }

    public class Extension {
        private int nr;
    }
}