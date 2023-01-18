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

        public void Park(int[] list, ParkingTicket[] objectList, int slot)
        {
            this.parkUnparkVehicle.Park(list, objectList, slot);
        }
        public void ParkingFull()
        {
            this.parkUnparkVehicle.ParkingFull();
        }

        public void Unpark(int[] list, ParkingTicket[] objectList, int slot)
        {
            this.parkUnparkVehicle.Unpark(list,objectList, slot);
        }

        public void ShowDetails(ParkingLot parkingLot)
        {
            this.showOccupancyDetails.ShowDetails(parkingLot);
        }
    }
}
