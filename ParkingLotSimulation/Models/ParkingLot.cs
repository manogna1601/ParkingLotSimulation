using ParkingLotSimulation.Services;

namespace ParkingLotSimulation.Models
{
    public class ParkingLot
    {
        public int TwoWheelerSlots;
        public int FourWheelerSlots;
        public int HeavyVehicleSlots;

        public ParkingLot(int twoWheelerSlots, int fourWheelerSlots, int heavyVehicleSlots)
        {
            TwoWheelerSlots = twoWheelerSlots;
            FourWheelerSlots = fourWheelerSlots;
            HeavyVehicleSlots = heavyVehicleSlots;
        }
    }
}
