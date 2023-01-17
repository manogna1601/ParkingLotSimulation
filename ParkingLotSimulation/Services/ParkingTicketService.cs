using ParkingLotSimulation.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation.Services
{
    internal class ParkingTicketService
    {
        public void IssueTicket(ParkingTicket ticket)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Vehicle Number: " + ticket.VehicleNumber);
            Console.WriteLine("Slot Number: " + ticket.SlotNumber);
            Console.WriteLine("In-Time: " + ticket.InTime);
            Console.WriteLine("Out-Time: " + ticket.OutTime);
            Console.WriteLine("\n");
            Console.WriteLine("Token Issued!");
            Console.WriteLine("\n");
        }

        public void ReturnTicket(ParkingTicket ticket)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Vehicle Number: " + ticket.VehicleNumber);
            Console.WriteLine("Slot Number: " + ticket.SlotNumber);
            Console.WriteLine("In-Time: " + ticket.InTime);
            Console.WriteLine("Out-Time: " + ticket.OutTime);
            Console.WriteLine("\n");
            Console.WriteLine("Vehicle Unparked! Thank You!");
            Console.WriteLine("\n");
        }
    }
}
