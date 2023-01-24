using ParkingLotSimulation.Models;

namespace ParkingLotSimulation.Interfaces
{
    public interface IHelperService
    {
        int numberOfVacancies(List<bool> arr);
        int slotNumber(List<bool> arr, bool key);
        void convertToJson(List<ParkingTicket> TwoWheelerObjectList, List<ParkingTicket> FourWheelerObjectList, List<ParkingTicket> HeavyVehicleObjectList);
    }
}