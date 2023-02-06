using ParkingLotSimulation.Models;

namespace ParkingLotSimulation.Interfaces
{
    public interface IShowOccupancyDetails
    {
        void ShowDetails(List<bool> twoWheelersList, List<bool> fourWheelersList, List<bool> heavyVehicleList, ParkingLot parkingLot);
    }
}