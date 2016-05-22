namespace Models {
    public class Car {
        
        private Player driver { get; set; }
        
        private int xCoord{ get; set; }
        
        private int yCoord{ get; set; }
        
        private int accelerationX { get; set; }
        
        private int accelerationY { get; set; }
        
        public Car(Player driver) {
            this.driver = driver;
        }
        
        public bool Drive(int newXCoord, int newYCoord) {
            // Verify that the move is correct
            return true;
        }
    }
}