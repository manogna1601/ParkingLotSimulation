using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation.Models
{
    public class Json
    {
        public List<ParkingTicket> TwoWheelers { get; set; }
        public List<ParkingTicket> FourWheelers { get; set; }
        public List<ParkingTicket> HeavyVehicles { get; set; }
    }
}
