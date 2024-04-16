using System.Collections.Generic;
using ParkingSystem.Data;

namespace ParkingSystem.Services
{
    public interface IParkingServices
    {
        int CreateParkingLot(int capacity);
        int Park(string policeNumber, VehicleType vehicleType, string color);
        int Leave(int lotId);
        List<Lot> GetStatus();
        int GetTotalSlotsByType(string type);
        int GetSlotByPoliceNumber(string policeNumber);
        List<int> GetSlotByColour(string colour);
        List<string> GetOddPoliceNumbers(string policeNumber);
        List<string> GetEvenPoliceNumbers(string policeNumber);
    }
}