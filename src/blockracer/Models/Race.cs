using System.Collections.Generic;

namespace BlockRacer.Models {
    ///<summary>Represents an race.</summary>
    public class Race {
        /// Represents the different states a game can have.
        public enum State { notStarted, ongoing, finished, aborted}
        
        // Unique id for this race.
        private System.Guid guid { get; set; }
        
        // Contains the list with players participating.
        private List<Player> players { get; set; }
        
        // Player who created the game.
        private Player creator { get; set; }
        
        // The map that is used for the race.
        private Map map { get; set; }
        
        private Dictionary<Player, Car> cars  { get; set; }
        
        // Which turn it is, a turn is considered complete
        // When all players have made their moves.
        private int turn { get; set; }
        
        // Keeps track on who has reported movement this turn.
        private List<Player> playersLeftThisTurn { get; set; }
        
        // Max nr of players that are allowed to participate.
        private int nrOfMaxPlayers { get; set; }
        
        // Minimum nr of players that needs to have joined.
        private int nrOfMinPlayers { get; set; }
                
        // Nr of joined players to this race
        private int nrOfJoinedPlayers { get; set; }
        
        // Current state of the race
        private State currentState { get; set; }
        
        /// All events associated with this race.
        private List<Event> events { get; set; }
        
        // Not showable in the main lobby. Invites only.
        private bool privateGame { get; set; }
        
        /// <summary>Constructor</summary>
        /// <param name="nrOfMinPlayers">Minimum nr of people needed</param>
        /// <param name="nrOfMaxPlayers">Maximum nr of people allowed</param>
        /// <param name="creator">The player who created the game</param>
        public Race(int nrOfMinPlayers, int nrOfMaxPlayers, Player creator) {
            this.guid = System.Guid.NewGuid();
            this.currentState = State.notStarted;
            this.nrOfJoinedPlayers = 0;
            this.nrOfMinPlayers = nrOfMinPlayers;
            this.nrOfMaxPlayers = nrOfMaxPlayers;
            this.creator = creator;
            this.cars = new Dictionary<Player, Car>();
            this.events = new List<Event>();
            this.players = new List<Player>();
        }
        
        public bool AddPlayer(Player player) {
            if (nrOfJoinedPlayers >= nrOfMaxPlayers - 1) {
                return false;
            }
            
            if (currentState != State.notStarted) {
                return false;
            }
            
            players.Add(player);
            nrOfJoinedPlayers++;
            
            this.cars[player] = new Car(player);
            return true;
        }
        
        // Removes a player from a game. A new player can't join
        // an existing game so we don't subtract the nr of players.
        public bool RemovePlayer(Player player) {
            return players.Remove(player); // works?
        }
        
        public List<Event> GetEvents() {
            return events;
        }
        
        public State GetState() {
            return currentState;
        }
        
        ///<summary>
        ///Add an event to the race.
        ///</summary>
        ///<param name="player">The player that is associated with the event</param>
        ///<param name="proposedEvent">The event to be added to the race</param>
        ///<returns>true if the event was added, otherwise false</returns>
        public bool AddEvent(Player player, Event proposedEvent) {
            return true;
        }
        
        public bool Start() {
            if (nrOfJoinedPlayers < nrOfMinPlayers - 1) {
                return false;
            }
            if (this.currentState == State.ongoing) {
                return false;
            }
            this.currentState = State.ongoing;
            return true;
        }
        
        public bool Stop() {
            if (currentState != State.ongoing) {
                return false;
            }
            this.currentState = State.aborted;
            return true;
        }
        
        public Car GetCar(Player player) {
            return cars[player];
        }
    }
}