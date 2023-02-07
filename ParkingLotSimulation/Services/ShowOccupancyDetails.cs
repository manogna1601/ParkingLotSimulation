using ParkingLotSimulation.Interfaces;
using ParkingLotSimulation.Models;

namespace ParkingLotSimulation.Services
{
    public class ShowOccupancyDetails : IShowOccupancyDetails
    {
        public void ShowDetails(int twoWheelerSlots, int fourWheelerSlots, int heavyVehicleSlots, int filledTwoWheelerSlots, int filledFourWheelerSlots, int filledheavyVehicleSlots)
        {
            Console.WriteLine("\n");
            Console.WriteLine("----------------- Parking Lot ------------------\n");
            Console.WriteLine("\t\t    Free Slots \t Occupied Slots");
            Console.WriteLine("Two Wheelers: \t\t" + (twoWheelerSlots - filledTwoWheelerSlots) + "\t\t" + filledTwoWheelerSlots);
            Console.WriteLine("Four Wheelers: \t\t" + (fourWheelerSlots - filledFourWheelerSlots) + "\t\t" + filledFourWheelerSlots);
            Console.WriteLine("Heavy Vehicles: \t" + (heavyVehicleSlots - filledheavyVehicleSlots) + "\t\t" + filledheavyVehicleSlots);
            Console.WriteLine("\n");
        }
    }
}
