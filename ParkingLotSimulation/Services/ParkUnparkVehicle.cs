using ParkingLotSimulation.Interfaces;
using ParkingLotSimulation.Models;
using System;
using System.Text.Json;
using System.Xml;

namespace ParkingLotSimulation.Services
{
    public class ParkUnparkVehicle : IParkUnparkVehicle
    {
        static string filename = "Details.json";

        public void Park(List<bool> list, List<ParkingTicket> objectList, int slot)
        {
            Console.WriteLine("Enter Vehicle Number: ");
            string vehicleNumber = Console.ReadLine();
            Console.WriteLine("Enter estimated parking time in hours: ");
            int estimatedHours = Convert.ToInt32(Console.ReadLine());
            DateTime inTime = DateTime.Now;
            DateTime outTime = inTime.AddHours(estimatedHours);
            ParkingTicket newParkingTicket = new ParkingTicket
            {
                VehicleNumber = vehicleNumber,
                SlotNumber = slot,
                InTime = inTime,
                OutTime = outTime
            };
            list[slot] = true;
            objectList[slot] = newParkingTicket;
            IssueTicket(newParkingTicket);
        }

        public void ParkingFull()
        {
            Console.WriteLine("\n Sorry! Parking is full!");
            Console.WriteLine("\n");
        }

        public void Unpark(List<bool> list, List<ParkingTicket> objectList, int slot)
        {
            if (list[slot] != false)
            {
                list[slot] = false;
                string penalty = Penalty(objectList[slot].OutTime, DateTime.Now);
                objectList[slot].OutTime = DateTime.Now;
                ReturnTicket(objectList[slot], penalty);
                objectList[slot].VehicleNumber = "";
                objectList[slot].SlotNumber = -1;
                objectList[slot].InTime = new DateTime();
                objectList[slot].OutTime = new DateTime();
            }
            else
            {
                Console.WriteLine("\nSlot is Empty!\n");
            }
        }

        public string Penalty(DateTime estimatedTime, DateTime actualTime)
        {
            int result = DateTime.Compare(estimatedTime, actualTime);
            if (result >= 0)
            {
                return "No Penalty!";
            }
            else
            {
                string penatly = Convert.ToString(Math.Abs(result) * 10);
                return penatly;
            }
        }
        public void IssueTicket(ParkingTicket ticket)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Vehicle Number: " + ticket.VehicleNumber);
            Console.WriteLine("Slot Number: " + ticket.SlotNumber);
            Console.WriteLine("In-Time: " + ticket.InTime);
            Console.WriteLine("Estimated Out-Time: " + ticket.OutTime);
            Console.WriteLine("\n");
            Console.WriteLine("Token Issued!");
            Console.WriteLine("\n");
        }
        public void ReturnTicket(ParkingTicket ticket, string penalty)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Vehicle Number: " + ticket.VehicleNumber);
            Console.WriteLine("Slot Number: " + ticket.SlotNumber);
            Console.WriteLine("In-Time: " + ticket.InTime);
            Console.WriteLine("Out-Time: " + ticket.OutTime);
            Console.WriteLine("Pentalty: " + penalty);
            Console.WriteLine("\n");
            Console.WriteLine("Vehicle Unparked! Thank You!");
            Console.WriteLine("\n");
        }
    }
}
