using ParkingLotSimulation.Interfaces;
using ParkingLotSimulation.Models;

namespace ParkingLotSimulation.Services
{
    public class ShowOccupancyDetails : IShowOccupancyDetails
    {
        public void ShowDetails(ParkingLot parkingLot)
        {
            Console.WriteLine("\n");
            Console.WriteLine("----------------- Parking Lot ------------------");
            Console.WriteLine("\t\t    Free Slots \t Occupied Slots");
            Console.WriteLine("Two Wheelers: \t\t" + Program.numberOfVacancies(parkingLot.TwoWheelersList) + "\t\t" + (parkingLot.TwoWheelerSlots - Program.numberOfVacancies(parkingLot.TwoWheelersList)));
            Console.WriteLine("Four Wheelers: \t\t" + Program.numberOfVacancies(parkingLot.FourWheelersList) + "\t\t" + (parkingLot.FourWheelerSlots - Program.numberOfVacancies(parkingLot.FourWheelersList)));
            Console.WriteLine("Heavy Vehicles: \t" + Program.numberOfVacancies(parkingLot.HeavyVehicleList) + "\t\t" + (parkingLot.HeavyVehicleSlots - Program.numberOfVacancies(parkingLot.HeavyVehicleList)));
            Console.WriteLine("\n");
        }
    }
}
