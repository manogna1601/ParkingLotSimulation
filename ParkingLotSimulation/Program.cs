using Newtonsoft.Json;
using ParkingLotSimulation;
using ParkingLotSimulation.Models;
using ParkingLotSimulation.Services;

public class Program
{
    static ParkUnparkVehicle _parkUnparkVehicle = new ParkUnparkVehicle();
    static ShowOccupancyDetails _showOccupancyDetails = new ShowOccupancyDetails();
    static HelperService _helperService = new HelperService();

    static Injector _injector = new Injector(_parkUnparkVehicle, _showOccupancyDetails, _helperService);
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter slots for two-wheeler parking:");
        int twoWheelerSlots = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter slots for four-wheeler parking:");
        int fourWheelerSlots = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter slots for heavy vehicle parking:");
        int heavyVehicleSlots = Convert.ToInt32(Console.ReadLine());

        ParkingLot parkingLot = new ParkingLot(twoWheelerSlots, fourWheelerSlots, heavyVehicleSlots);


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
                            int x = Convert.ToInt32(Console.ReadLine());

                            switch (x)
                            {
                                case 1:
                                    if (_injector.numberOfVacancies(parkingLot.TwoWheelersList) != 0)
                                    {
                                        int slot = _injector.slotNumber(parkingLot.TwoWheelersList, false);
                                        _injector.Park(parkingLot.TwoWheelersList, parkingLot.TwoWheelerObjectList, slot);
                                        _injector.convertToJson(parkingLot.TwoWheelerObjectList, parkingLot.FourWheelerObjectList, parkingLot.HeavyVehicleObjectList);
                                    }
                                    else
                                    {
                                        _injector.ParkingFull();
                                    }
                                    break;

                                case 2:
                                    if (_injector.numberOfVacancies(parkingLot.FourWheelersList) != 0)
                                    {
                                        int slot = _injector.slotNumber(parkingLot.FourWheelersList, false);
                                        _injector.Park(parkingLot.FourWheelersList, parkingLot.FourWheelerObjectList, slot);
                                        _injector.convertToJson(parkingLot.TwoWheelerObjectList, parkingLot.FourWheelerObjectList, parkingLot.HeavyVehicleObjectList);
                                    }
                                    else
                                    {
                                        _injector.ParkingFull();
                                    }
                                    break;

                                case 3:
                                    if (_injector.numberOfVacancies(parkingLot.HeavyVehicleList) != 0)
                                    {
                                        int slot = _injector.slotNumber(parkingLot.HeavyVehicleList, false);
                                        _injector.Park(parkingLot.HeavyVehicleList, parkingLot.HeavyVehicleObjectList, slot);
                                        _injector.convertToJson(parkingLot.TwoWheelerObjectList, parkingLot.FourWheelerObjectList, parkingLot.HeavyVehicleObjectList);
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
                        if (_injector.numberOfVacancies(parkingLot.TwoWheelersList) == twoWheelerSlots && _injector.numberOfVacancies(parkingLot.FourWheelersList) == fourWheelerSlots && _injector.numberOfVacancies(parkingLot.HeavyVehicleList) == heavyVehicleSlots)
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
                                        if (_injector.numberOfVacancies(parkingLot.TwoWheelersList) == twoWheelerSlots)
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
                                                _injector.Unpark(parkingLot.TwoWheelersList, parkingLot.TwoWheelerObjectList, unparkSlot);
                                                _injector.convertToJson(parkingLot.TwoWheelerObjectList, parkingLot.FourWheelerObjectList, parkingLot.HeavyVehicleObjectList);
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Sorry! No such Slot!\n");
                                            }
                                        }
                                        break;

                                    case 2:
                                        if (_injector.numberOfVacancies(parkingLot.FourWheelersList) == fourWheelerSlots)
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
                                                _injector.Unpark(parkingLot.FourWheelersList, parkingLot.FourWheelerObjectList, unparkSlot);
                                                _injector.convertToJson(parkingLot.TwoWheelerObjectList, parkingLot.FourWheelerObjectList, parkingLot.HeavyVehicleObjectList);
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Sorry! No such Slot!\n");
                                            }
                                        }
                                        break;

                                    case 3:
                                        if (_injector.numberOfVacancies(parkingLot.HeavyVehicleList) == heavyVehicleSlots)
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
                                                _injector.Unpark(parkingLot.HeavyVehicleList, parkingLot.HeavyVehicleObjectList, unparkSlot);
                                                _injector.convertToJson(parkingLot.TwoWheelerObjectList, parkingLot.FourWheelerObjectList, parkingLot.HeavyVehicleObjectList);
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Sorry! No such Slot!\n");
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
                        _injector.ShowDetails(parkingLot);
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