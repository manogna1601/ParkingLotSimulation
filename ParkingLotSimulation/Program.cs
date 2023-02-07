using Newtonsoft.Json;
using ParkingLotSimulation;
using ParkingLotSimulation.Models;
using ParkingLotSimulation.Services;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

public class Program
{
    public static List<Vehicle> vehicleList = new List<Vehicle>();
    public static List<Ticket> ticketList = new List<Ticket>();

    public static int CountVehiclesByType<T>() where T : Vehicle
    {
        return vehicleList.OfType<T>().Count();
    }

    static ParkUnparkVehicle _parkUnparkVehicle = new ParkUnparkVehicle();
    static ShowOccupancyDetails _showOccupancyDetails = new ShowOccupancyDetails();

    static Injector _injector = new Injector(_parkUnparkVehicle, _showOccupancyDetails);
    private static void Main(string[] args)
    {
        Console.WriteLine("------------- Initialize your Parking Lot ------------\n");
        Console.WriteLine("Enter slots for two-wheeler parking:");
        int twoWheelerSlots = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter slots for four-wheeler parking:");
        int fourWheelerSlots = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter slots for heavy vehicle parking:");
        int heavyVehicleSlots = Convert.ToInt32(Console.ReadLine());

        ParkingLotStructure parkingLotStructure = new ParkingLotStructure
        {
            Tickets = new List<ParkingTicket>()
        };

        Console.WriteLine("\n");
        Console.WriteLine("----------------- Parking Lot ------------------ \n");
        Console.WriteLine("Two Wheeler Slots: " + twoWheelerSlots); ;
        Console.WriteLine("Four Wheeler Slots: " + fourWheelerSlots);
        Console.WriteLine("Heavy Vehicle Slots: " + heavyVehicleSlots);
        Console.WriteLine("\n");

        bool flag = true;
        while (flag)
        {
            Console.WriteLine("Enter 1 => Park Vehicle");
            Console.WriteLine("Enter 2 => Unpark Vehicle");
            Console.WriteLine("Enter 3 => Show Occupancy Details");
            Console.WriteLine("Enter 4 => Exit");

            try
            {
                int response = Convert.ToInt32(Console.ReadLine());
                int vehicleType;

                switch (response)
                {
                    case 1:
                        Console.WriteLine("Enter 1 => Two-Wheeler Parking");
                        Console.WriteLine("Enter 2 => Four-Wheeler Parking");
                        Console.WriteLine("Enter 3 => Heavy Vehicle Parking");

                        int type = Convert.ToInt32 (Console.ReadLine());

                        switch (type)
                        {
                            case 1:
                                if (CountVehiclesByType<TwoWheeler>() < twoWheelerSlots)
                                {
                                    _injector.Park(vehicleList, type, ticketList);
                                }

                                else
                                {
                                    _injector.ParkingFull();
                                }
                                break;
                            case 2:
                                if (CountVehiclesByType<FourWheeler>() < fourWheelerSlots)
                                {
                                    _injector.Park(vehicleList, type, ticketList);
                                }

                                else
                                {
                                    _injector.ParkingFull();
                                }
                                break;
                            case 3:
                                if (CountVehiclesByType<HeavyVehicle>() < heavyVehicleSlots)
                                {
                                    _injector.Park(vehicleList, type, ticketList);
                                }

                                else
                                {
                                    _injector.ParkingFull();
                                }
                                break;
                        }
                        break;

                    case 2:
                        if (ticketList.Count == 0)
                        {
                            Console.WriteLine("\n No Vehicles to Unpark!");
                            Console.WriteLine("\n");
                        }

                        else
                        {
                            Console.WriteLine("Enter your Vehicle Number: ");
                            string unparkVehicle = Console.ReadLine();

                            _injector.Unpark(vehicleList, unparkVehicle, ticketList);
                        }
                        break;

                    case 3:
                        _injector.ShowDetails(twoWheelerSlots, fourWheelerSlots, heavyVehicleSlots, CountVehiclesByType<TwoWheeler>(), CountVehiclesByType<FourWheeler>(), CountVehiclesByType<HeavyVehicle>());
                        break;

                    case 4:
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Invalid");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n---------- Give Valid Input! ----------\n");
            }

        }
    }
}