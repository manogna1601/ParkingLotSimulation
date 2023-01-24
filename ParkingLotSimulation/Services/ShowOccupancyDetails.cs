using ParkingLotSimulation.Interfaces;
using ParkingLotSimulation.Models;

namespace ParkingLotSimulation.Services
{
    public class ShowOccupancyDetails : IShowOccupancyDetails
    {
        HelperService _helperService = new HelperService();
        public void ShowDetails(ParkingLot parkingLot)
        {
            Console.WriteLine("\n");
            Console.WriteLine("----------------- Parking Lot ------------------");
            Console.WriteLine("\t\t    Free Slots \t Occupied Slots");
            Console.WriteLine("Two Wheelers: \t\t" + _helperService.numberOfVacancies(parkingLot.TwoWheelersList) + "\t\t" + (parkingLot.TwoWheelerSlots - _helperService.numberOfVacancies(parkingLot.TwoWheelersList)));
            Console.WriteLine("Four Wheelers: \t\t" + _helperService.numberOfVacancies(parkingLot.FourWheelersList) + "\t\t" + (parkingLot.FourWheelerSlots - _helperService.numberOfVacancies(parkingLot.FourWheelersList)));
            Console.WriteLine("Heavy Vehicles: \t" + _helperService.numberOfVacancies(parkingLot.HeavyVehicleList) + "\t\t" + (parkingLot.HeavyVehicleSlots - _helperService.numberOfVacancies(parkingLot.HeavyVehicleList)));
            Console.WriteLine("\n");
        }
    }
}
