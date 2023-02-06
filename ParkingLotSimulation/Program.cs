using Newtonsoft.Json;
using ParkingLotSimulation;
using ParkingLotSimulation.Models;
using ParkingLotSimulation.Services;
using System.Text.Json.Serialization;

public class Program
{
    static ParkUnparkVehicle _parkUnparkVehicle = new ParkUnparkVehicle();
    static ShowOccupancyDetails _showOccupancyDetails = new ShowOccupancyDetails();

    static Injector _injector = new Injector(_parkUnparkVehicle, _showOccupancyDetails);
    private static void Main(string[] args)
    {
        Console.WriteLine("------------- Initialize your Parking Lot ------------");
        Console.WriteLine("Enter slots for two-wheeler parking:");
        int twoWheelerSlots = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter slots for four-wheeler parking:");
        int fourWheelerSlots = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter slots for heavy vehicle parking:");
        int heavyVehicleSlots = Convert.ToInt32(Console.ReadLine());

        ParkingLot parkingLot = new ParkingLot(twoWheelerSlots, fourWheelerSlots, heavyVehicleSlots);

        List<bool> twoWheelersList = new List<bool>(twoWheelerSlots);
        List<bool> fourWheelersList = new List<bool>(fourWheelerSlots);
        List<bool> heavyVehicleList = new List<bool>(heavyVehicleSlots);

        List<ParkingTicket> twoWheelerObjectList = new List<ParkingTicket>(twoWheelerSlots);
        List<ParkingTicket> fourWheelerObjectList = new List<ParkingTicket>(fourWheelerSlots);
        List<ParkingTicket> heavyVehicleObjectList = new List<ParkingTicket>(heavyVehicleSlots);


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

                switch (response)
                {
                    case 1:
                        Console.WriteLine("Enter Type of Vehicle");
                        Console.WriteLine("1 => Two-Wheeler");
                        Console.WriteLine("2 => Four-Wheeler");
                        Console.WriteLine("3 => Heavy Vehicle");

                        try
                        {
                            int park = Convert.ToInt32(Console.ReadLine());

                            switch (park)
                            {
                                case 1:
                                    if (twoWheelersList.Count != twoWheelerSlots)
                                    {
                                        _injector.Park(twoWheelersList, twoWheelerObjectList);
                                    }
                                    else if(twoWheelerSlots == 0)
                                    {
                                        Console.WriteLine("\nNo Two Wheeler slots!\n");
                                    }
                                    else
                                    {
                                        _injector.ParkingFull();
                                    }
                                    break;

                                case 2:
                                    if (fourWheelersList.Count != fourWheelerSlots)
                                    {
                                        _injector.Park(fourWheelersList, fourWheelerObjectList);
                                    }
                                    else if (fourWheelerSlots == 0)
                                    {
                                        Console.WriteLine("\nNo Four Wheeler slots!\n");
                                    }
                                    else
                                    {
                                        _injector.ParkingFull();
                                    }
                                    break;

                                case 3:
                                    if (heavyVehicleList.Count != heavyVehicleSlots)
                                    {
                                        _injector.Park(heavyVehicleList, heavyVehicleObjectList);
                                    }
                                    else if (heavyVehicleSlots == 0)
                                    {
                                        Console.WriteLine("\nNo Heavy Vehicle slots!\n");
                                    }
                                    else
                                    {
                                        _injector.ParkingFull();
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Invalid Input");
                                    break;
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("\n---------- Give Valid Input! ----------\n");
                        }
                        break;

                    case 2:
                        if (twoWheelersList.Count == 0 && fourWheelersList.Count == 0 && heavyVehicleList.Count == 0)
                        {
                            Console.WriteLine("\n No Vehicles to Unpark!");
                            Console.WriteLine("\n");
                        }

                        else
                        {
                            Console.WriteLine("Enter 1 => Two Wheeler");
                            Console.WriteLine("Enter 2 => Four Wheeler");
                            Console.WriteLine("Enter 3 => Heavy Vehicle");

                            try
                            {
                                int unparkResponse = Convert.ToInt32(Console.ReadLine());

                                switch (unparkResponse)
                                {
                                    case 1:
                                        if (twoWheelerSlots == 0)
                                        {
                                            Console.WriteLine("\nNo Two Wheeler slots!\n");
                                        }
                                        else
                                        {
                                            if (twoWheelersList.Count == 0)
                                            {
                                                Console.WriteLine("\n No Vehicles to Unpark!");
                                                Console.WriteLine("\n");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter Slot Number:");
                                                int unparkSlot = Convert.ToInt32(Console.ReadLine());
                                                try
                                                {
                                                    _injector.Unpark(twoWheelersList, twoWheelerObjectList, unparkSlot);
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Sorry! No such Slot!\n");
                                                }
                                            } 
                                        }
                                        break;

                                    case 2:
                                        if (fourWheelerSlots == 0)
                                        {
                                            Console.WriteLine("\nNo Four Wheeler slots!\n");
                                        }
                                        else
                                        {
                                            if (fourWheelersList.Count == 0)
                                            {
                                                Console.WriteLine("\n No Vehicles to Unpark!");
                                                Console.WriteLine("\n");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter Slot Number:");
                                                int unparkSlot = Convert.ToInt32(Console.ReadLine());
                                                try
                                                {
                                                    _injector.Unpark(fourWheelersList, fourWheelerObjectList, unparkSlot);
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Sorry! No such Slot!\n");
                                                }
                                            } 
                                        }
                                        break;

                                    case 3:
                                        if (heavyVehicleSlots == 0)
                                        {
                                            Console.WriteLine("\nNo Heavy Vehicle slots!\n");
                                        }
                                        else
                                        {
                                            if (heavyVehicleList.Count == 0)
                                            {
                                                Console.WriteLine("\n No Vehicles to Unpark!");
                                                Console.WriteLine("\n");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Enter Slot Number:");
                                                int unparkSlot = Convert.ToInt32(Console.ReadLine());
                                                try
                                                {
                                                    _injector.Unpark(heavyVehicleList, heavyVehicleObjectList, unparkSlot);
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Sorry! No such Slot!\n");
                                                }
                                            } 
                                        }
                                        break;

                                    default:
                                        Console.WriteLine("Invalid Input!");
                                        break;
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\n---------- Give Valid Input! ----------\n");
                            }
                        }
                        break;

                    case 3:
                        _injector.ShowDetails(twoWheelersList, fourWheelersList, heavyVehicleList, parkingLot);
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