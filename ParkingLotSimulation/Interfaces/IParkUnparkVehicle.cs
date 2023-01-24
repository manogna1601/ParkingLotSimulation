using ParkingLotSimulation.Models;

namespace ParkingLotSimulation.Interfaces
{
    public interface IParkUnparkVehicle
    {
        void Park(List<bool> list, List<ParkingTicket> objectList, int slot);
        void ParkingFull();
        void Unpark(List<bool> list, List<ParkingTicket> objectList, int slot);
        string Penalty(DateTime estimatedTime, DateTime actualTime);
    }
}