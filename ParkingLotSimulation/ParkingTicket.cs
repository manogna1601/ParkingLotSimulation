using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    internal class ParkingTicket
    {
        public string VehicleNumber;
        public string SlotNumber;
        public DateTime InTime;
        public DateTime OutTime;
        public ParkingTicket(string vehicleNumber, string slotNumber, DateTime inTime, DateTime outTime)
        {
            this.VehicleNumber = vehicleNumber;
            this.SlotNumber = slotNumber;
            this.InTime = inTime;
            this.OutTime = outTime;
        }

        public void IssueTicket()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Vehicle Number: " + VehicleNumber);
            Console.WriteLine("Slot Number: " + SlotNumber);
            Console.WriteLine("In-Time: " + InTime);
            Console.WriteLine("Out-Time: " + OutTime);
            Console.WriteLine("\n");
            Console.WriteLine("Token Issued!");
            Console.WriteLine("\n");
        }

        public void ReturnTicket()
        {
            Console.WriteLine("\n");
            Console.WriteLine("Vehicle Number: " + VehicleNumber);
            Console.WriteLine("Slot Number: " + SlotNumber);
            Console.WriteLine("In-Time: " + InTime);
            Console.WriteLine("Out-Time: " + OutTime);
            Console.WriteLine("\n");
        }

    }
}
