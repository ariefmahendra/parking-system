namespace ParkingSystem.Data
{
    public class Lot
    {
        public int slot { get; set; }
        public string policeNumber { get; set; }
        public VehicleType type { get; set; }
        public string colour { get; set; }

        public Lot(int slot, string policeNumber, VehicleType type, string colour)
        {
            this.slot = slot;
            this.policeNumber = policeNumber;
            this.type = type;
            this.colour = colour;
        }
    }
}