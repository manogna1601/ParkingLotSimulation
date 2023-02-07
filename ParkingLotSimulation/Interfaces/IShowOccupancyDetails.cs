using ParkingLotSimulation.Models;

namespace ParkingLotSimulation.Interfaces
{
    public interface IShowOccupancyDetails
    {
        void ShowDetails(int twoWheelerSlots, int fourWheelerSlots, int heavyVehicleSlots, int filledTwoWheelerSlots, int filledFourWheelerSlots, int filledheavyVehicleSlots);
    }
}