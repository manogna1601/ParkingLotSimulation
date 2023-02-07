using ParkingLotSimulation.Models;

namespace ParkingLotSimulation.Interfaces
{
    public interface IParkUnparkVehicle
    {
        void Park(List<Vehicle> vehicles, int vehicleType, List<Ticket> tickets);
        void ParkingFull();
        void Unpark(List<Vehicle> vehicles, string unparkVehicle, List<Ticket> tickets);
        string Penalty(DateTime estimatedTime, DateTime actualTime);
    }
}