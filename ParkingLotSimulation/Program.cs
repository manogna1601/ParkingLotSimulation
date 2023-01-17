using Microsoft.VisualBasic;
using ParkingLotSimulation.Modals;
using ParkingLotSimulation.Services;

internal class Program
{
    public int numberOfVacancies(int[] arr)
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

    public int slotNumber(int[] arr, int x)
    {
        int idx;
        idx = Array.FindIndex(arr, i => i == x);
        return idx;
    }
    private static void Main(string[] args)
    {
        Program p = new Program();

        Console.WriteLine("Enter slots for two-wheeler parking:");
        int twoWheelerSlots = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter slots for four-wheeler parking:");
        int fourWheelerSlots = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter slots for heavy vehicle parking:");
        int heavyVehicleSlots = Convert.ToInt32(Console.ReadLine());

        ParkingLot parkingLot = new ParkingLot(twoWheelerSlots, fourWheelerSlots, heavyVehicleSlots); 

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

                    ParkUnparkVehicle park = new ParkUnparkVehicle();

                    switch (x)
                    {
                        case 1:
                            if (p.numberOfVacancies(parkingLot.TwoWheelersList) != 0)
                            {
                                int slot = p.slotNumber(parkingLot.TwoWheelersList, 0);
                                string slotNumber = "TW-" + Convert.ToString(slot);
                                park.Park(parkingLot.TwoWheelersList, parkingLot.TwoWheelerObjectList, slotNumber, slot);
                            }
                            else
                            {
                                park.ParkingFull();
                            }
                            break;

                        case 2:
                            if (p.numberOfVacancies(parkingLot.FourWheelersList) != 0)
                            {
                                int slot = p.slotNumber(parkingLot.FourWheelersList, 0);
                                string slotNumber = "FW-" + Convert.ToString(slot);
                                park.Park(parkingLot.FourWheelersList, parkingLot.FourWheelerObjectList, slotNumber, slot);
                            }
                            else
                            {
                                park.ParkingFull();
                            }
                            break;

                        case 3:
                            if (p.numberOfVacancies(parkingLot.HeavyVehicleList) != 0)
                            {
                                int slot = p.slotNumber(parkingLot.HeavyVehicleList, 0);
                                string slotNumber = "HV-" + Convert.ToString(slot);
                                park.Park(parkingLot.HeavyVehicleList, parkingLot.HeavyVehicleObjectList, slotNumber, slot);
                            }
                            else
                            {
                                park.ParkingFull();
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid Input");

                            break;
                    }

                    break;

                case 2:

                    ParkUnparkVehicle unpark = new ParkUnparkVehicle();

                    if (p.numberOfVacancies(parkingLot.TwoWheelersList) == twoWheelerSlots && p.numberOfVacancies(parkingLot.FourWheelersList) == fourWheelerSlots && p.numberOfVacancies(parkingLot.HeavyVehicleList) == heavyVehicleSlots)
                    {
                        Console.WriteLine("\n No Vehicles to Unpark!");
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine("Enter the Slot Number you want to unpark: ");
                        string unParkVehicle = Console.ReadLine();

                        if (unParkVehicle.Substring(0, 2) == "TW")
                        {
                            try
                            {
                                int slot = Convert.ToInt32(unParkVehicle.Substring(3));
                                unpark.Unpark(parkingLot.TwoWheelersList, parkingLot.TwoWheelerObjectList, slot);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Sorry! No such Slot!\n");
                            }
                        }

                        else if (unParkVehicle.Substring(0, 2) == "FW")
                        {
                            try
                            {
                                int slot = Convert.ToInt32(unParkVehicle.Substring(3));
                                unpark.Unpark(parkingLot.FourWheelersList, parkingLot.FourWheelerObjectList, slot);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Sorry! No such Slot!\n");
                            }
                        }

                        else if (unParkVehicle.Substring(0, 2) == "HV")
                        {
                            try
                            {
                                int slot = Convert.ToInt32(unParkVehicle.Substring(3));
                                unpark.Unpark(parkingLot.HeavyVehicleList, parkingLot.HeavyVehicleObjectList, slot);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Sorry! No such Slot!\n");
                            }
                        }

                        else
                        {
                            Console.WriteLine("\n No Such Slot Found! \n");
                        }
                    }

                    break;

                case 3:
                    ShowOccupancyDetails details = new ShowOccupancyDetails();
                    details.ShowDetails(parkingLot, p);

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