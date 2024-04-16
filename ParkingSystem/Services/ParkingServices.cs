using System;
using System.Collections.Generic;
using ParkingSystem.Data;

namespace ParkingSystem.Services
{
    public class ParkingServices : IParkingServices
    {

        private List<Lot> lots = new List<Lot>();
        private int capacity;
        
        public int CreateParkingLot(int capacity)
        {
            return this.capacity = capacity;
        }

        public int Park(string policeNumber, VehicleType vehicleType, string color)
        {
            int lotId;
            
            if (lots.Count == 0)
            {
                lotId = 1;
            } else
            {
                lotId = lots.Count + 1;
            }

            if (lotId > capacity)
            {
                throw new Exception("Sorry, parking lot is full");
            }
            
            var lot = new Lot(lotId, policeNumber, vehicleType, color);
            
            lots.Add(lot);

            return lotId;
        }

        public int Leave(int lotId)
        {
            foreach (var lot in lots)
            {
                if (lot.slot == lotId)
                {
                    lots.Remove(lot);
                    return lotId;
                }

            }
            
            throw new Exception("Slot not found");
        }

        public List<Lot> GetStatus()
        {
            throw new System.NotImplementedException();
        }

        public int GetTotalSlotsByType(string type)
        {
            throw new System.NotImplementedException();
        }

        public int GetFreeSlotsByPoliceNumber(string type)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetFreeSlotsByColor(string color)
        {
            throw new System.NotImplementedException();
        }

        public List<string> GetOddPoliceNumbers(string color)
        {
            throw new System.NotImplementedException();
        }

        public List<string> GetEvenPoliceNumbers(string color)
        {
            throw new System.NotImplementedException();
        }
    }
}