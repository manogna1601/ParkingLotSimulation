namespace ParkingLotSimulation.Models
{
    public class ParkingTicket
    {
        public string VehicleNumber { get; set; }
        public int SlotNumber { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }

        /*public ParkingTicket(string vehicleNumber, int slotNumber, DateTime inTime, DateTime outTime)
        {
            VehicleNumber = vehicleNumber;
            SlotNumber = slotNumber;
            InTime = inTime;
            OutTime = outTime;
        }*/

    }
}
