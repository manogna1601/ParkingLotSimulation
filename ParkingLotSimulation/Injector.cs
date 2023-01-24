using ParkingLotSimulation.Interfaces;
using ParkingLotSimulation.Models;

namespace ParkingLotSimulation
{
    public class Injector
    {
        private IParkUnparkVehicle parkUnparkVehicle;
        private IShowOccupancyDetails showOccupancyDetails;
        private IHelperService helperService;
        public Injector(IParkUnparkVehicle _parkUnparkVehicle, IShowOccupancyDetails _showOccupancyDetails, IHelperService _helperService) 
        {
            parkUnparkVehicle = _parkUnparkVehicle;
            showOccupancyDetails = _showOccupancyDetails;
            helperService = _helperService;
        }

        public void Park(List<bool> list, List<ParkingTicket> objectList, int slot)
        {
            this.parkUnparkVehicle.Park(list, objectList, slot);
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

        public void ShowDetails(ParkingLot parkingLot)
        {
            this.showOccupancyDetails.ShowDetails(parkingLot);
        }

        public int numberOfVacancies(List<bool> arr)
        {
            return this.helperService.numberOfVacancies(arr);
        }
        public int slotNumber(List<bool> arr, bool key)
        {
            return this.helperService.slotNumber(arr,key);
        }

        public void convertToJson(List<ParkingTicket> TwoWheelerObjectList, List<ParkingTicket> FourWheelerObjectList, List<ParkingTicket> HeavyVehicleObjectList)
        {
            this.helperService.convertToJson(TwoWheelerObjectList, FourWheelerObjectList, HeavyVehicleObjectList);
        }
    }
}
