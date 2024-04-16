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
        int GetFreeSlotsByPoliceNumber(string type);
        List<int> GetFreeSlotsByColor(string color);
        List<string> GetOddPoliceNumbers(string color);
        List<string> GetEvenPoliceNumbers(string color);
    }
}