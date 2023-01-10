using Microsoft.VisualBasic;
using ParkingLotSimulation;

internal class Program
{
    int numberOfVacancies(int[] arr)
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

    int slotNumber(int[] arr, int x)
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

        int[] twoWheelersList = new int[twoWheelerSlots];
        ParkingTicket[] twoWheelerObjectList = new ParkingTicket[twoWheelerSlots];
        int[] fourWheelersList = new int[fourWheelerSlots];
        ParkingTicket[] fourWheelerObjectList = new ParkingTicket[fourWheelerSlots];
        int[] heavyVehicleList = new int[heavyVehicleSlots];
        ParkingTicket[] heavyVehicleObjectList = new ParkingTicket[heavyVehicleSlots];

        Console.WriteLine("\n");
        Console.WriteLine("----------------- Parking Lot ------------------ \n");
        Console.WriteLine("Two Wheeler Slots: " + twoWheelerSlots);
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
                            if (p.numberOfVacancies(twoWheelersList) != 0)
                            {
                                Console.WriteLine("Enter Vehicle Number: ");
                                string vehicleNumber = Console.ReadLine();
                                int slot = p.slotNumber(twoWheelersList, 0);
                                string slotNumber = "TW-" + Convert.ToString(slot);
                                DateTime inTime = DateTime.Now;
                                DateTime outTime = DateTime.Now.AddHours(1);
                                ParkingTicket newParkingTicket = new ParkingTicket(vehicleNumber, slotNumber, inTime, outTime);
                                twoWheelersList[slot] = 1;
                                twoWheelerObjectList[slot] = newParkingTicket;
                                newParkingTicket.IssueTicket();
                            }
                            else
                            {
                                Console.WriteLine("\n Sorry! Parking is full!");
                                Console.WriteLine("\n");
                            }
                            break;

                        case 2:
                            if (p.numberOfVacancies(fourWheelersList) != 0)
                            {
                                Console.WriteLine("Enter Vehicle Number: ");
                                string vehicleNumber = Console.ReadLine();
                                int slot = p.slotNumber(fourWheelersList, 0);
                                string slotNumber = "FW-" + Convert.ToString(slot);
                                DateTime inTime = DateTime.Now;
                                DateTime outTime = DateTime.Now.AddHours(1);
                                ParkingTicket newParkingTicket = new ParkingTicket(vehicleNumber, slotNumber, inTime, outTime);
                                fourWheelersList[slot] = 1;
                                fourWheelerObjectList[slot] = newParkingTicket;
                                newParkingTicket.IssueTicket();
                            }
                            else
                            {
                                Console.WriteLine("\n Sorry! Parking is full!");
                                Console.WriteLine("\n");
                            }
                            break;

                        case 3:
                            if (p.numberOfVacancies(heavyVehicleList) != 0)
                            {
                                Console.WriteLine("Enter Vehicle Number: ");
                                string vehicleNumber = Console.ReadLine();
                                int slot = p.slotNumber(heavyVehicleList, 0);
                                string slotNumber = "HV-" + Convert.ToString(slot);
                                DateTime inTime = DateTime.Now;
                                DateTime outTime = DateTime.Now.AddHours(1);
                                ParkingTicket newParkingTicket = new ParkingTicket(vehicleNumber, slotNumber, inTime, outTime);
                                heavyVehicleList[slot] = 1;
                                heavyVehicleObjectList[slot] = newParkingTicket;
                                newParkingTicket.IssueTicket();
                            }
                            else
                            {
                                Console.WriteLine("\n Sorry! Parking is full!");
                                Console.WriteLine("\n");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                    break;

                case 2:
                    if (p.numberOfVacancies(twoWheelersList) == twoWheelerSlots && p.numberOfVacancies(fourWheelersList) == fourWheelerSlots && p.numberOfVacancies(heavyVehicleList) == heavyVehicleSlots)
                    {
                        Console.WriteLine("No Vehicles to Unpark!");
                    }
                    else
                    {
                        Console.WriteLine("Enter the Slot Number you want to unpark: ");
                        string unParkVehicle = Console.ReadLine();

                        if (unParkVehicle.Substring(0, 2) == "TW")
                        {
                            int slot = Convert.ToInt32(unParkVehicle.Substring(3));
                            twoWheelersList[slot] = 0;
                            twoWheelerObjectList[slot].OutTime = DateTime.Now;
                            Console.WriteLine("Vehicle Unparked! Thank You!");
                            Console.WriteLine("\n");
                        }

                        else if (unParkVehicle.Substring(0, 2) == "FW")
                        {
                            int slot = Convert.ToInt32(unParkVehicle.Substring(3));
                            fourWheelersList[slot] = 0;
                            fourWheelerObjectList[slot].OutTime = DateTime.Now;
                            Console.WriteLine("Vehicle Unparked! Thank You!");
                            Console.WriteLine("\n");
                        }

                        else if (unParkVehicle.Substring(0, 2) == "HV")
                        {
                            int slot = Convert.ToInt32(unParkVehicle.Substring(3));
                            heavyVehicleList[slot] = 0;
                            heavyVehicleObjectList[slot].OutTime = DateTime.Now;
                            Console.WriteLine("Vehicle Unparked! Thank You!");
                            Console.WriteLine("\n");
                        }

                        else
                        {
                            Console.WriteLine("No Such Vehicle Found!");
                        }
                    }

                    break;

                case 3:
                    Console.WriteLine("\n");
                    Console.WriteLine("----------------- Parking Lot ------------------");
                    Console.WriteLine("\t\t    Free Slots \t Occupied Slots");
                    Console.WriteLine("Two Wheelers: \t\t" + p.numberOfVacancies(twoWheelersList) + "\t\t" + (twoWheelerSlots - p.numberOfVacancies(twoWheelersList)));
                    Console.WriteLine("Four Wheelers: \t\t" + p.numberOfVacancies(fourWheelersList) + "\t\t" + (fourWheelerSlots - p.numberOfVacancies(fourWheelersList)));
                    Console.WriteLine("Heavy Vehicles: \t" + p.numberOfVacancies(heavyVehicleList) + "\t\t" + (heavyVehicleSlots - p.numberOfVacancies(heavyVehicleList)));
                    Console.WriteLine("\n");
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