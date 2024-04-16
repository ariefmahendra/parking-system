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

            Console.WriteLine("Parking System");

            while (true)
            {
                Console.WriteLine("=========================");
                Console.WriteLine("1. Create Parking Lot");
                Console.WriteLine("2. Park");
                Console.WriteLine("3. Leave");
                Console.WriteLine("4. Get Status");
                Console.WriteLine("5. Get Total Slots By Type");
                Console.WriteLine("6. Get Free Slots By Police Number");
                Console.WriteLine("7. Get Free Slots By Color");
                Console.WriteLine("8. Get Odd Police Numbers");
                Console.WriteLine("9. Get Even Police Numbers");
                Console.WriteLine("0. Exit");
                Console.WriteLine("=========================");

                int menu;
                try{
                    Console.Write("Choose an option: ");
                    menu = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
                
                switch (menu)
                {
                    case 1:
                        Console.Write("create_parking_lot: ");
                        try
                        {
                            var capacity = int.Parse(Console.ReadLine());
                            var parkingLot = ParkingServices.CreateParkingLot(capacity);
                            Console.WriteLine("Created a parking lot with " + parkingLot +" slots");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        Console.Write("park: ");
                        try
                        {
                            var input = Console.ReadLine().Split(" ");
                            var policeNumber = input[0];
                            var color = input[1];
                            var vehicleType = (VehicleType)Enum.Parse(typeof(VehicleType), input[2]);
                            
                            var lotId = ParkingServices.Park(policeNumber, vehicleType, color);
                            
                            Console.WriteLine("Allocated slot number: " + lotId);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        Console.Write("leave: ");
                        try
                        {
                            var input = int.Parse(Console.ReadLine());
                            var lotId = ParkingServices.Leave(input);
                            Console.WriteLine("Slot number " + lotId + " is free");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            }
        }
    }
}