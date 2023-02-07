using Newtonsoft.Json;
using ParkingLotSimulation.Interfaces;
using ParkingLotSimulation.Models;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Xml;

namespace ParkingLotSimulation.Services
{
    public class ParkUnparkVehicle : IParkUnparkVehicle
    {
        int slot = 0;

        public void Park(List<Vehicle> vehicles, int vehicleType, List<Ticket> tickets)
        {
            Regex vehicleNumberRegex = new Regex(@"[A-Z][A-Z]-[0-9][0-9]-[A-Z][A-Z]-[0-9][0-9][0-9][0-9]");

            string vehicleNumber;

            Console.WriteLine("Enter Vehicle Number: ");
            string vehicleNumberInput = Console.ReadLine();
            while (!vehicleNumberRegex.IsMatch(vehicleNumberInput))
            {
                Console.WriteLine("Enter valid Vehicle Number: (Pattern: XX-00-XX-0000)");
                vehicleNumberInput = Console.ReadLine();
            }

            vehicleNumber = vehicleNumberInput;

            if (vehicleType == 1)
            {
                TwoWheeler newTwoWheeler = new TwoWheeler
                {
                    VehicleNumber = vehicleNumber
                };
                vehicles.Add(newTwoWheeler);
            }
            else if (vehicleType == 2)
            {
                FourWheeler newFourWheeler = new FourWheeler
                {
                    VehicleNumber = vehicleNumber,
                    VehicleType = "Four-Wheeler"
                };
                vehicles.Add(newFourWheeler);
            }
            else
            {
                HeavyVehicle newHeavyVehicle = new HeavyVehicle
                {
                    VehicleNumber = vehicleNumber,
                    VehicleType = "Heavy Vehicle"
                };
                vehicles.Add(newHeavyVehicle);
            }

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
                catch (Exception ex)
                {
                    flag = true;
                    Console.WriteLine(ex.Message);
                }
            }

            Ticket newTicket = new Ticket()
            {
                SlotNumber = slot++,
                InTime = DateTime.Now,
                OutTime = DateTime.Now.AddHours(estimatedHours)
            };

            tickets.Add(newTicket);

            IssueTicket(vehicles[vehicles.Count-1],newTicket);
        }

        

        public void ParkingFull()
        {
            Console.WriteLine("\n Sorry! Parking is full!");
            Console.WriteLine("\n");
        }

        public void Unpark(List<Vehicle> vehicles, string unparkVehicle, List<Ticket> tickets)
        {
            bool flag = false;
            
            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].VehicleNumber == unparkVehicle)
                {
                    string penalty = Penalty(tickets[i].OutTime, DateTime.Now);
                    tickets[i].OutTime = DateTime.Now;
                    ReturnTicket(tickets[i], penalty, vehicles[i]);
                    vehicles.RemoveAt(i);
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("\nNo such Slot!\n");
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

        public void IssueTicket(Vehicle vehicle, Ticket ticket)
        {
            Console.WriteLine("\n");
            Console.WriteLine("****** Parking Ticket ******\n");
            Console.WriteLine("Vehicle Number: " + vehicle.VehicleNumber);
            Console.WriteLine("SLot Number: " + ticket.SlotNumber);
            Console.WriteLine("In-Time: " + ticket.InTime);
            Console.WriteLine("Estimated Out-Time: " + ticket.OutTime);
            Console.WriteLine("\n");
        }

        public void ReturnTicket(Ticket ticket, string penalty, Vehicle vehicle)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Vehicle Number: " + vehicle.VehicleNumber);
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
