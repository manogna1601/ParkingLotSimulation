using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation.Modals
{
    internal class ParkingTicket
    {
        public string VehicleNumber;
        public string SlotNumber;
        public DateTime InTime;
        public DateTime OutTime;

        public ParkingTicket(string vehicleNumber, string slotNumber, DateTime inTime, DateTime outTime)
        {
            VehicleNumber = vehicleNumber;
            SlotNumber = slotNumber;
            InTime = inTime;
            OutTime = outTime;
        }

    }
}
