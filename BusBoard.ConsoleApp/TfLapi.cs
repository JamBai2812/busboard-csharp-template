using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard
{
    public class TfLApiReader
    {
        private readonly RestClient _client = new RestClient("https://api.tfl.gov.uk");
        
        public IEnumerable<Bus> GetBusesAtStop(string stopcode)
        {

            var request = new RestRequest("StopPoint/{stopcode}/Arrivals", Method.GET)
                .AddUrlSegment("stopcode", stopcode);

            var response = _client.Get<List<Bus>>(request);

            return response.Data.OrderBy(bus => bus.TimeToStation);
        }
        
        public void GetStops(string lat, string lon, string rd)
        {
            var request =
                new RestRequest(
                    $"StopPoint/?stopTypes=NaptanPublicBusCoachTram&radius={rd}&modes=bus&lat={lat}&lon={lon}",
                    Method.GET);
            var response = _client.Get<List<Stop>>(request);
        
            var stopList = response.Data;

            foreach (var stop in stopList)
            {
                Console.WriteLine(stop.Distance);
                Console.WriteLine(stop.NaptanId);
            }
            
        }

        public List<Bus> GetBusesAtMultipleStops(List<Stop> stopList)
        {
            //incomplete
            var busList = new List<Bus>();
            return busList;
        }
        
        


    }
}