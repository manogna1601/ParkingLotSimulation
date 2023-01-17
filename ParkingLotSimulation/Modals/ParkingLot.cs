using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation.Modals
{
    internal class ParkingLot
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

            Console.WriteLine("\n");
            Console.WriteLine("----------------- Parking Lot ------------------ \n");
            Console.WriteLine("Two Wheeler Slots: " + this.TwoWheelerSlots); ;
            Console.WriteLine("Four Wheeler Slots: " + this.FourWheelerSlots);
            Console.WriteLine("Heavy Vehicle Slots: " + this.HeavyVehicleSlots);
            Console.WriteLine("\n");
        }

    }
}
