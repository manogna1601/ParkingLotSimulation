using ParkingLotSimulation.Interfaces;
using ParkingLotSimulation.Models;

namespace ParkingLotSimulation.Services
{
    public class ShowOccupancyDetails : IShowOccupancyDetails
    {
        public void ShowDetails(List<bool> twoWheelersList, List<bool> fourWheelersList, List<bool> heavyVehicleList, ParkingLot parkingLot)
        {
            Console.WriteLine("\n");
            Console.WriteLine("----------------- Parking Lot ------------------");
            Console.WriteLine("\t\t    Free Slots \t Occupied Slots");
            Console.WriteLine("Two Wheelers: \t\t" + (parkingLot.TwoWheelerSlots - twoWheelersList.Count) + "\t\t" + (twoWheelersList.Count));
            Console.WriteLine("Four Wheelers: \t\t" + (parkingLot.FourWheelerSlots - fourWheelersList.Count) + "\t\t" + (fourWheelersList.Count));
            Console.WriteLine("Heavy Vehicles: \t" + (parkingLot.HeavyVehicleSlots - heavyVehicleList.Count) + "\t\t" + (heavyVehicleList.Count));
            Console.WriteLine("\n");
        }
    }
}
