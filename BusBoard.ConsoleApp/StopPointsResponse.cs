using System;
using System.Collections.Generic;

namespace BusBoard
{
    public class StopPointsResponse
    {
        //Properties
        public List<Stop> StopPoints { get; set; }
    }
    
    public class Stop
    {
        //Properties
        public float Distance { get; set; }
        public string NaptanId { get; set; }
        public string CommonName { get; set; }
        public string StopLetter { get; set; }
        //Methods
        public void PrintDetails()
        {
            Console.WriteLine($"\n{CommonName}({StopLetter})");
            Console.WriteLine($"{Distance} metres away");
            Console.WriteLine($"Stop code: {NaptanId}");
        }
    }
}