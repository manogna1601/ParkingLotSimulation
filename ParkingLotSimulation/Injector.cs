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

        public void Park(List<bool> list, List<ParkingTicket> objectList)
        {
            this.parkUnparkVehicle.Park(list, objectList);
        }
        public void ParkingFull()
        {
            this.parkUnparkVehicle.ParkingFull();
        }

        public void Unpark(List<bool> list, List<ParkingTicket> objectList, int slot)
        {
            this.parkUnparkVehicle.Unpark(list,objectList, slot);
        }

        public string Penalty(DateTime estimatedTime, DateTime actualTime)
        {
            return this.parkUnparkVehicle.Penalty(estimatedTime,actualTime);
        }

        public void ShowDetails(List<bool> twoWheelersList, List<bool> fourWheelersList, List<bool> heavyVehicleList, ParkingLot parkingLot)
        {
            this.showOccupancyDetails.ShowDetails(twoWheelersList, fourWheelersList, heavyVehicleList, parkingLot);
        }
    }
}
