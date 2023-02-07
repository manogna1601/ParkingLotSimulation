using ParkingLotSimulation.Interfaces;
using ParkingLotSimulation.Models;

namespace ParkingLotSimulation
{
    public class Injector
    {
        private IParkUnparkVehicle parkUnparkVehicle;
        private IShowOccupancyDetails showOccupancyDetails;
        public Injector(IParkUnparkVehicle _parkUnparkVehicle, IShowOccupancyDetails _showOccupancyDetails) 
        {
            parkUnparkVehicle = _parkUnparkVehicle;
            showOccupancyDetails = _showOccupancyDetails;
        }

        public void Park(List<Vehicle> vehicles, int vehicleType, List<Ticket> tickets)
        {
            this.parkUnparkVehicle.Park(vehicles, vehicleType, tickets);
        }
        public void ParkingFull()
        {
            this.parkUnparkVehicle.ParkingFull();
        }
        public void Unpark(List<Vehicle> vehicles, string unparkVehicle, List<Ticket> tickets)
        {
            this.parkUnparkVehicle.Unpark(vehicles, unparkVehicle, tickets);
        }

        public string Penalty(DateTime estimatedTime, DateTime actualTime)
        {
            return this.parkUnparkVehicle.Penalty(estimatedTime,actualTime);
        }

        public void ShowDetails(int twoWheelerSlots, int fourWheelerSlots, int heavyVehicleSlots, int filledTwoWheelerSlots, int filledFourWheelerSlots, int filledheavyVehicleSlots)
        {
            this.showOccupancyDetails.ShowDetails(twoWheelerSlots, fourWheelerSlots, heavyVehicleSlots, filledTwoWheelerSlots, filledFourWheelerSlots, filledheavyVehicleSlots);
        }
    }
}
