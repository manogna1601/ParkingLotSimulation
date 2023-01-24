using ParkingLotSimulation.Interfaces;
using ParkingLotSimulation.Models;

namespace ParkingLotSimulation.Services
{
    public class HelperService : IHelperService
    {
        public int numberOfVacancies(List<bool> arr)
        {
            int ans = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i] == false)
                {
                    ans++;
                }
            }
            return ans;
        }

        public int slotNumber(List<bool> arr, bool key)
        {
            int idx;
            idx = arr.IndexOf(key);
            return idx;
        }

        public void convertToJson(List<ParkingTicket> TwoWheelerObjectList, List<ParkingTicket> FourWheelerObjectList, List<ParkingTicket> HeavyVehicleObjectList)
        {
            Json json = new Json()
            {
                TwoWheelers = TwoWheelerObjectList,
                FourWheelers = FourWheelerObjectList,
                HeavyVehicles = HeavyVehicleObjectList
            };

            var formattedData = Newtonsoft.Json.JsonConvert.SerializeObject(json);

            string filename = @"Details.json";

            File.WriteAllText(filename, formattedData);

            Console.WriteLine(File.ReadAllText(filename));
        }

    }
}
