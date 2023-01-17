using ParkingLotSimulation.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation.Services
{
    internal class ParkUnparkVehicle
    {
        public int slotNumber(int[] arr, int x)
        {
            int idx;
            idx = Array.FindIndex(arr, i => i == x);
            return idx;
        }
        public void Park(int[] list, ParkingTicket[] objectList, string slotNumber, int slot)
        {
            Console.WriteLine("Enter Vehicle Number: ");
            string vehicleNumber = Console.ReadLine();
            DateTime inTime = DateTime.Now;
            DateTime outTime = new DateTime();
            ParkingTicket newParkingTicket = new ParkingTicket(vehicleNumber, slotNumber, inTime, outTime);
            list[slot] = 1;
            objectList[slot] = newParkingTicket;
            ParkingTicketService s = new ParkingTicketService();
            s.IssueTicket(newParkingTicket);
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
            ParkingTicketService s = new ParkingTicketService();
            s.ReturnTicket(objectList[slot]);
        }
    }
}
