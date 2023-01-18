using ParkingLotSimulation;
using ParkingLotSimulation.Models;
using ParkingLotSimulation.Services;

public class Program
{
    static ParkUnparkVehicle _parkUnparkVehicle = new ParkUnparkVehicle();
    static ShowOccupancyDetails _showOccupancyDetails = new ShowOccupancyDetails();
    static Injector _injector = new Injector(_parkUnparkVehicle, _showOccupancyDetails);
    public static int numberOfVacancies(int[] arr)
    {
        int ans = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == 0)
            {
                ans++;
            }
        }
        return ans;
    }

    public static int slotNumber(int[] arr, int x)
    {
        int idx;
        idx = Array.FindIndex(arr, i => i == x);
        return idx;
    }

    public static void IssueTicket(ParkingTicket ticket)
    {
        Console.WriteLine("\n");
        Console.WriteLine("Vehicle Number: " + ticket.VehicleNumber);
        Console.WriteLine("Slot Number: " + ticket.SlotNumber);
        Console.WriteLine("In-Time: " + ticket.InTime);
        Console.WriteLine("Out-Time: " + ticket.OutTime);
        Console.WriteLine("\n");
        Console.WriteLine("Token Issued!");
        Console.WriteLine("\n");
    }

    public static void ReturnTicket(ParkingTicket ticket)
    {
        Console.WriteLine("\n");
        Console.WriteLine("Vehicle Number: " + ticket.VehicleNumber);
        Console.WriteLine("Slot Number: " + ticket.SlotNumber);
        Console.WriteLine("In-Time: " + ticket.InTime);
        Console.WriteLine("Out-Time: " + ticket.OutTime);
        Console.WriteLine("\n");
        Console.WriteLine("Vehicle Unparked! Thank You!");
        Console.WriteLine("\n");
    }
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
            int response = Convert.ToInt32(Console.ReadLine());
            switch (response)
            {
                case 1:
                    Console.WriteLine("Enter Type of Vehicle");
                    Console.WriteLine("1 => Two-Wheeler");
                    Console.WriteLine("2 => Four-Wheeler");
                    Console.WriteLine("3 => Heavy Vehicle");
                    int x = Convert.ToInt32(Console.ReadLine());

                    switch (x)
                    {
                        case 1:
                            if (Program.numberOfVacancies(parkingLot.TwoWheelersList) != 0)
                            {
                                int slot = Program.slotNumber(parkingLot.TwoWheelersList, 0);
                                _injector.Park(parkingLot.TwoWheelersList, parkingLot.TwoWheelerObjectList, slot);
                            }
                            else
                            {
                                _injector.ParkingFull();
                            }
                            break;

                        case 2:
                            if (Program.numberOfVacancies(parkingLot.FourWheelersList) != 0)
                            {
                                int slot = Program.slotNumber(parkingLot.FourWheelersList, 0);
                                _injector.Park(parkingLot.FourWheelersList, parkingLot.FourWheelerObjectList, slot);
                            }
                            else
                            {
                                _injector.ParkingFull();
                            }
                            break;

                        case 3:
                            if (Program.numberOfVacancies(parkingLot.HeavyVehicleList) != 0)
                            {
                                int slot = Program.slotNumber(parkingLot.HeavyVehicleList, 0);
                                _injector.Park(parkingLot.HeavyVehicleList, parkingLot.HeavyVehicleObjectList, slot);
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
                    break;

                case 2:
                    if (Program.numberOfVacancies(parkingLot.TwoWheelersList) == twoWheelerSlots && Program.numberOfVacancies(parkingLot.FourWheelersList) == fourWheelerSlots && Program.numberOfVacancies(parkingLot.HeavyVehicleList) == heavyVehicleSlots)
                    {
                        Console.WriteLine("\n No Vehicles to Unpark!");
                        Console.WriteLine("\n");
                    }

                    else
                    {
                        Console.WriteLine("Enter 1 => Two Wheeler");
                        Console.WriteLine("Enter 2 => Four Wheeler");
                        Console.WriteLine("Enter 3 => Heavy Vehicle");

                        int unparkResponse = Convert.ToInt32(Console.ReadLine());

                        switch (unparkResponse)
                        {
                            case 1:
                                if(Program.numberOfVacancies(parkingLot.TwoWheelersList) == twoWheelerSlots)
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
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Sorry! No such Slot!\n");
                                    } 
                                }
                                break;

                            case 2:
                                if(Program.numberOfVacancies(parkingLot.FourWheelersList) == fourWheelerSlots)
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
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Sorry! No such Slot!\n");
                                    } 
                                }
                                break;

                            case 3:
                                if (Program.numberOfVacancies(parkingLot.HeavyVehicleList) == heavyVehicleSlots)
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
    }
}