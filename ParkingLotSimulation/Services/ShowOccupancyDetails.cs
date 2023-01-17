using ParkingLotSimulation.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation.Services
{
    internal class ShowOccupancyDetails
    {
        public void ShowDetails(ParkingLot parkingLot, Program p)
        {
            Console.WriteLine("\n");
            Console.WriteLine("----------------- Parking Lot ------------------");
            Console.WriteLine("\t\t    Free Slots \t Occupied Slots");
            Console.WriteLine("Two Wheelers: \t\t" + p.numberOfVacancies(parkingLot.TwoWheelersList) + "\t\t" + (parkingLot.TwoWheelerSlots - p.numberOfVacancies(parkingLot.TwoWheelersList)));
            Console.WriteLine("Four Wheelers: \t\t" + p.numberOfVacancies(parkingLot.FourWheelersList) + "\t\t" + (parkingLot.FourWheelerSlots - p.numberOfVacancies(parkingLot.FourWheelersList)));
            Console.WriteLine("Heavy Vehicles: \t" + p.numberOfVacancies(parkingLot.HeavyVehicleList) + "\t\t" + (parkingLot.HeavyVehicleSlots - p.numberOfVacancies(parkingLot.HeavyVehicleList)));
            Console.WriteLine("\n");
        }
    }
}
