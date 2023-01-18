using ParkingLotSimulation.Interfaces;
using ParkingLotSimulation.Models;

namespace ParkingLotSimulation.Services
{
    public class ParkUnparkVehicle : IParkUnparkVehicle
    {
        public void Park(int[] list, ParkingTicket[] objectList, int slot)
        {
            Console.WriteLine("Enter Vehicle Number: ");
            string vehicleNumber = Console.ReadLine();
            DateTime inTime = DateTime.Now;
            DateTime outTime = new DateTime();
            ParkingTicket newParkingTicket = new ParkingTicket(vehicleNumber, slot, inTime, outTime);
            list[slot] = 1;
            objectList[slot] = newParkingTicket;
            Program.IssueTicket(newParkingTicket);
          
        }

        public void ParkingFull()
        {
            Console.WriteLine("\n Sorry! Parking is full!");
            Console.WriteLine("\n");
        }

        public void Unpark(int[] list, ParkingTicket[] objectList, int slot)
        {
            list[slot] = 0;
            objectList[slot].OutTime = DateTime.Now;
            Program.ReturnTicket(objectList[slot]);
        }
    }
}
