using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation.Models
{
    public class Ticket
    {
        public int SlotNumber { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
    }
}
