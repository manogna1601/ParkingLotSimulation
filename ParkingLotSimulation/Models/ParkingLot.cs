using ParkingLotSimulation.Services;

namespace ParkingLotSimulation.Models
{
    public class ParkingLot
    {
        public int TwoWheelerSlots;
        public int FourWheelerSlots;
        public int HeavyVehicleSlots;
        public List<bool> TwoWheelersList;
        public List<bool> FourWheelersList;
        public List<bool> HeavyVehicleList;
        public List<ParkingTicket> TwoWheelerObjectList;
        public List<ParkingTicket> FourWheelerObjectList;
        public List<ParkingTicket> HeavyVehicleObjectList;

        static ParkUnparkVehicle _parkUnparkVehicle = new ParkUnparkVehicle();
        static ShowOccupancyDetails _showOccupancyDetails = new ShowOccupancyDetails();
        static HelperService _helperService = new HelperService();

        static Injector _injector = new Injector(_parkUnparkVehicle, _showOccupancyDetails, _helperService);

        public ParkingLot(int twoWheelerSlots, int fourWheelerSlots, int heavyVehicleSlots)
        {
            this.TwoWheelerSlots = twoWheelerSlots;
            this.FourWheelerSlots = fourWheelerSlots;
            this.HeavyVehicleSlots = heavyVehicleSlots;
            this.TwoWheelersList = new List<bool>(TwoWheelerSlots);
            this.FourWheelersList = new List<bool>(FourWheelerSlots);
            this.HeavyVehicleList = new List<bool>(HeavyVehicleSlots);
            this.TwoWheelerObjectList = new List<ParkingTicket>(TwoWheelerSlots);
            this.FourWheelerObjectList = new List<ParkingTicket>(FourWheelerSlots);
            this.HeavyVehicleObjectList = new List<ParkingTicket>(HeavyVehicleSlots);

            for (int i = 0; i < TwoWheelerSlots; i++)
            {
                TwoWheelersList.Add(false);
            }

            for (int i = 0; i < FourWheelerSlots; i++)
            {
                FourWheelersList.Add(false);
            }
            for (int i = 0; i < HeavyVehicleSlots; i++)
            {
                HeavyVehicleList.Add(false);
            }

            ParkingTicket dummyTicket = new ParkingTicket
            {
                VehicleNumber = "",
                SlotNumber = -1,
                InTime = new DateTime(),
                OutTime = new DateTime()
            };

            for (int i = 0; i < TwoWheelerSlots; i++)
            {
                TwoWheelerObjectList.Add(dummyTicket);
            }

            for (int i = 0; i < FourWheelerSlots; i++)
            {
                FourWheelerObjectList.Add(dummyTicket);
            }

            for (int i = 0; i < HeavyVehicleSlots; i++)
            {
                HeavyVehicleObjectList.Add(dummyTicket);
            }

            //_injector.convertToJson(TwoWheelerObjectList, FourWheelerObjectList, HeavyVehicleObjectList);

        }
    }
}
