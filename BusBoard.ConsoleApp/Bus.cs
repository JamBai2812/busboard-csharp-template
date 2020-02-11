using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard
{
    public class Bus
    {
        /*private string route;
        private string destination;
        private int timeTilArrival;*/

        public string VehicleId { get; set; }
        public string StationName { get; set; }
        public string DestinationName { get; set; }
        public int TimeToStation { get; set; }
        

    }
}