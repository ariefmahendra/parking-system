namespace ParkingSystem.Data
{
    public class Lot
    {
        public int slot { get; set; }
        public string policeNumber { get; set; }
        public VehicleType type { get; set; }
        public string color { get; set; }

        public Lot(int slot, string policeNumber, VehicleType type, string color)
        {
            this.slot = slot;
            this.policeNumber = policeNumber;
            this.type = type;
            this.color = color;
        }
    }
}