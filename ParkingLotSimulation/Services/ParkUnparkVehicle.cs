using Newtonsoft.Json;
using ParkingLotSimulation.Interfaces;
using ParkingLotSimulation.Models;
using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Xml;

namespace ParkingLotSimulation.Services
{
    public class ParkUnparkVehicle : IParkUnparkVehicle
    {
        static string filename = "Details.json";
        int slot = 0;

        public void Park(List<bool> list, List<ParkingTicket> objectList)
        {
            Regex vehicleNumberRegex = new Regex(@"[A-Z][A-Z]-[0-9][0-9]-[A-Z][A-Z]-[0-9][0-9][0-9][0-9]");

            string vehicleNumber;

            Console.WriteLine("Enter Vehicle Number:  Pattern: XX-00-XX-0000");
            string vehicleNumberInput = Console.ReadLine();
            while(!vehicleNumberRegex.IsMatch(vehicleNumberInput)) 
            {
                Console.WriteLine("Enter Vehicle Number: Pattern: XX-00-XX-0000");
                vehicleNumberInput = Console.ReadLine();
            }

            vehicleNumber = vehicleNumberInput;

            bool flag = true;

            int estimatedHours = 0;

            

            while (flag)
            {
                Console.WriteLine("Enter estimated parking time in hours: ");
                try
                {
                    int estimatedHoursInput = Convert.ToInt32(Console.ReadLine());
                    estimatedHours = estimatedHoursInput;
                    flag = false;
                }
                catch (Exception)
                {
                    flag = true;
                } 
            }

            DateTime inTime = DateTime.Now;
            DateTime outTime = inTime.AddHours(estimatedHours);

            list.Add(true);
            this.slot++;

            ParkingTicket newParkingTicket = new ParkingTicket
            {
                VehicleNumber = vehicleNumber,
                SlotNumber = slot,
                InTime = inTime,
                OutTime = outTime
            };

            
            objectList.Add(newParkingTicket);

            IssueTicket(newParkingTicket);
        }

        public void ParkingFull()
        {
            Console.WriteLine("\n Sorry! Parking is full!");
            Console.WriteLine("\n");
        }

        public void Unpark(List<bool> list, List<ParkingTicket> objectList, int slot)
        {
            list.Remove(true);
            for (int i = 0; i < objectList.Count; i++)
            {
                string penalty = Penalty(objectList[i].OutTime, DateTime.Now);
                objectList[i].OutTime = DateTime.Now;
                ReturnTicket(objectList[i], penalty);
                break;
            }
                
                for (int i=0; i<objectList.Count; i++)
                {
                    if (objectList[i].SlotNumber == slot)
                    {
                        objectList.Remove(objectList[i]);
                    }
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
