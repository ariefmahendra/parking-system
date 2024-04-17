using System;
using System.Collections.Generic;
using System.Linq;
using ParkingSystem.Data;

namespace ParkingSystem.Services
{
    public class ParkingServices : IParkingServices
    {

        private List<Lot> lots = new List<Lot>();
        private List<int> removedLots = new List<int>();
        private int capacity;
        
        public int CreateParkingLot(int capacity)
        {
            return this.capacity = capacity;
        }

        public int Park(string policeNumber, VehicleType vehicleType, string color)
        {
            var lotId = 0;

            if (lots.Count == 0)
            {
                if (removedLots.Count != 0)
                {
                    lotId = removedLots.First();
                    removedLots.Remove(lotId);
                }
                else
                {
                    lotId = 1;
                }
            }
            else if (removedLots.Count != 0)
            {
                lotId = removedLots.First();
                removedLots.Remove(lotId);
            }
            else
            {
                lotId = lots.Max(lot => lot.slot) + 1;
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
            foreach (var lot in lots.Where(lot => lot.slot == lotId))
            {
                lots.Remove(lot);
                removedLots.Add(lotId);
                return lotId;
            }

            throw new Exception("Slot not found");
        }

        public List<Lot> GetStatus()
        {
            lots.Sort((x, y) => x.slot.CompareTo(y.slot));
            return lots;
        }

        public int GetTotalSlotsByType(string type)
        {
            var count = 0;
            if (type == VehicleType.Mobil.ToString())
            {
                count += lots.Count(lot => lot.type.ToString() == type);
            } else if (type == VehicleType.Motor.ToString())
            {
                count += lots.Count(lot => lot.type.ToString() == type);
            }
            else
            {
                throw new Exception("Invalid vehicle type");
            }

            return count;
        }

        public int GetSlotByPoliceNumber(string policeNumber)
        {
            foreach (var lot in lots.Where(lot => lot.policeNumber == policeNumber))
            {
                return lot.slot;
            }

            throw new Exception("Not Found");
        }

        public List<int> GetSlotByColour(string colour)
        {
            return (from lot in lots where lot.colour == colour select lot.slot).ToList();
        }

        public List<string> GetOddPoliceNumbers()
        {
            return (from lot in lots let no = lot.policeNumber.Split('-') where int.Parse(no[1]) % 2 != 0 select lot.policeNumber).ToList();
        }

        public List<string> GetEvenPoliceNumbers()
        {
            return (from lot in lots let no = lot.policeNumber.Split('-') where int.Parse(no[1]) % 2 == 0 select lot.policeNumber).ToList();
        }

        public List<string> GetPoliceNumberByColour(string colour)
        {
            return (from lot in lots where lot.colour == colour select lot.policeNumber).ToList();
        }
    }
}