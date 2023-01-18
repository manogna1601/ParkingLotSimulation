namespace ParkingLotSimulation.Models
{
    public class ParkingTicket
    {
        public string VehicleNumber;
        public int SlotNumber;
        public DateTime InTime;
        public DateTime OutTime;

        public ParkingTicket(string vehicleNumber, int slotNumber, DateTime inTime, DateTime outTime)
        {
            VehicleNumber = vehicleNumber;
            SlotNumber = slotNumber;
            InTime = inTime;
            OutTime = outTime;
        }

    }
}
