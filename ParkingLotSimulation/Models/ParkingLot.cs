namespace ParkingLotSimulation.Models
{
    public class ParkingLot
    {
        public int TwoWheelerSlots;
        public int FourWheelerSlots;
        public int HeavyVehicleSlots;
        public int[] TwoWheelersList;
        public int[] FourWheelersList;
        public int[] HeavyVehicleList;
        public ParkingTicket[] TwoWheelerObjectList;
        public ParkingTicket[] FourWheelerObjectList;
        public ParkingTicket[] HeavyVehicleObjectList;
        public ParkingLot(int twoWheelerSlots, int fourWheelerSlots, int heavyVehicleSlots)
        {
            this.TwoWheelerSlots = twoWheelerSlots;
            this.FourWheelerSlots = fourWheelerSlots;
            this.HeavyVehicleSlots = heavyVehicleSlots;
            this.TwoWheelersList = new int[TwoWheelerSlots];
            this.FourWheelersList = new int[FourWheelerSlots];
            this.HeavyVehicleList = new int[HeavyVehicleSlots];
            this.TwoWheelerObjectList = new ParkingTicket[TwoWheelerSlots];
            this.FourWheelerObjectList = new ParkingTicket[FourWheelerSlots];
            this.HeavyVehicleObjectList = new ParkingTicket[HeavyVehicleSlots];
        }

    }
}
