using System;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard
{
    public class Bus
    {
        //Properties
        public string VehicleId { get; set; }
        public string StationName { get; set; }
        public string DestinationName { get; set; }
        public int TimeToStation { get; set; }
        public string LineId { get; set; }
        
        //Methods
        public void PrintDetails()
        {
            Console.WriteLine($"Bus Number: {LineId}");
            Console.WriteLine($"Bus destination: {DestinationName}");
            Console.WriteLine($"Time until arrival: {TimeToStation / 60} minute(s) and {TimeToStation % 60} second(s)\n");
        }
    }
}