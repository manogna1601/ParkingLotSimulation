using ParkingLotSimulation.Models;

namespace ParkingLotSimulation.Interfaces
{
    public interface IParkUnparkVehicle
    {
        void Park(int[] list, ParkingTicket[] objectList, int slot);
        void ParkingFull();
        void Unpark(int[] list, ParkingTicket[] objectList, int slot);
    }
}