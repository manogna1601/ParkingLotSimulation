using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    internal class ParkingLot
    {
        public int TwoWheelerSlots;
        public int FourWheelerSlots;
        public int HeavyVehicleSlots;
        public ParkingLot(int twoWheelerSlots, int fourWheelerSlots, int heavyVehicleSlots) 
        {
            this.TwoWheelerSlots = twoWheelerSlots;
            this.FourWheelerSlots = fourWheelerSlots;
            this.HeavyVehicleSlots = heavyVehicleSlots;
        }
    }
}
