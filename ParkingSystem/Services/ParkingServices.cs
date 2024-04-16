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
            return lots;
        }

        public int GetTotalSlotsByType(string type)
        {
            var count = 0;
            if (type == VehicleType.Mobil.ToString())
            {
                foreach (var lot in lots)
                {
                    if (lot.type.ToString() == type)
                    {
                        count++;
                    }
                }
            } else if (type == VehicleType.Motor.ToString())
            {
                foreach (var lot in lots)
                {
                    if (lot.type.ToString() == type)
                    {
                        count++;
                    }
                }
            }
            else
            {
                throw new Exception("Invalid vehicle type");
            }

            return count;
        }

        public int GetSlotByPoliceNumber(string policeNumber)
        {
            foreach (var lot in lots)
            {
                if (lot.policeNumber == policeNumber) 
                {
                    return lot.slot;
                }
            }
            
            throw new Exception("Not Found");
        }

        public List<int> GetSlotByColour(string colour)
        {
            var slotList = new List<int>();

            foreach (var lot in lots)
            {
                if (lot.colour == colour)
                {
                    slotList.Add(lot.slot);
                }
            }

            return slotList;
        }

        public List<string> GetOddPoliceNumbers(string policeNumber)
        {
            throw new System.NotImplementedException();
        }

        public List<string> GetEvenPoliceNumbers(string policeNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}