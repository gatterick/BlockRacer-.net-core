namespace BlockRacer.Mvc.Models {
    public class Car {        
        public string Id { get; set; }

        private Player Driver { get; set; }
        
        private int XCoord{ get; set; }
        
        private int YCoord{ get; set; }
        
        private int AccelerationX { get; set; }
        
        private int AccelerationY { get; set; }
        
        public bool Crashed { get; set; }
        
        public Car(Player driver) {
            this.Driver = driver;
        }
        
        public bool Drive(int newXCoord, int newYCoord) {
            // Verify that the move is correct from the
            // cars point of view.
            return true;
        }
        
        
    }
}