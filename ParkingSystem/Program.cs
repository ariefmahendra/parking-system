using System;
using ParkingSystem.Data;
using ParkingSystem.Services;

namespace ParkingSystem
{
    class Program
    {
        
        private static readonly IParkingServices ParkingServices = new ParkingServices();

        private static void Main(string[] args)
        {

            Console.WriteLine("===============");
            Console.WriteLine("Parking System");
            Console.WriteLine("===============");

            while (true)
            {
                var inputSplit = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);

                var command = inputSplit[0].ToLower();
                
                switch (command)
                {
                    case "create_parking_lot":
                        try
                        {
                            var capacity = int.Parse(inputSplit[1]);
                            var parkingLot = ParkingServices.CreateParkingLot(capacity);
                            Console.WriteLine("Created a parking lot with " + parkingLot + " slots");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "park" :
                        try
                        {
                            var policeNumber = inputSplit[1];
                            var color = inputSplit[2];
                            var vehicleType = (VehicleType) Enum.Parse(typeof(VehicleType), inputSplit[3]);
                            var park = ParkingServices.Park(policeNumber, vehicleType, color);
                            Console.WriteLine($"Allocated slot number: {park}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "leave":
                        try
                        {
                            var slot = int.Parse(inputSplit[1]);
                            var leave = ParkingServices.Leave(slot);
                            Console.WriteLine($"Slot number {leave} is free");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "status":
                        var status = ParkingServices.GetStatus();
                        Console.WriteLine("Slot     No.     Type     Registration No Colour");
                        foreach (var lot in status)
                        {
                            Console.WriteLine($"{lot.slot} {lot.policeNumber} {lot.type} {lot.colour}");
                        }
                        break;
                    case "type_of_vehicles":
                        try
                        {
                            var type = inputSplit[1];
                            var totalSlotsByType = ParkingServices.GetTotalSlotsByType(type);
                            Console.WriteLine(totalSlotsByType);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "slot_number_for_registration_number":
                        try
                        {
                            var registrationNumber = inputSplit[1];
                            var slotByPoliceNumber = ParkingServices.GetSlotByPoliceNumber(registrationNumber);
                            Console.WriteLine(slotByPoliceNumber);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "registration_numbers_for_vehicles_with_colour":
                        var colour = inputSplit[1];
                        var slotByColour = ParkingServices.GetSlotByColour(colour);
                        foreach (var slot in slotByColour)
                        {
                            Console.Write(slot + " ");
                        }
                        break;
                }
            }
        }
    }
}