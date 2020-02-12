using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    public class PrintToConsole
    {
        public static void NextFiveBuses(IEnumerable<Bus> busList)
        {
            Console.WriteLine("------------------------------------------------------");
            foreach (var bus in busList.Take(5))
            {
                // Console.WriteLine($"\n {i+1})");
                Console.WriteLine("Bus destination: " + bus.DestinationName);
                Console.WriteLine("Bus number: " + bus.LineId);
                if (bus.TimeToStation / 60 == 1)
                {
                    Console.WriteLine("Time til arrival: " + bus.TimeToStation / 60 + " minute\n");
                }
                else
                {
                    Console.WriteLine("Time til arrival: " + bus.TimeToStation / 60 + " minutes\n");
                }
            }
            Console.WriteLine("===================================");
            
        }

        public static void StopsNearMe(List<Stop> stopList)
        {
            Console.WriteLine("=================================\nThe Stops nearest to you are:");
            foreach (var stop in stopList.Take(2))
            {
                Console.WriteLine($"\n{stop.CommonName}({stop.StopLetter}):");
                Console.WriteLine($"{stop.Distance} metres away");
                Console.WriteLine($"Stop code: {stop.NaptanId}");
            }
            Console.WriteLine("=================================");
        }

        /*public static void PrintPostCodeLonLat(PostcodeData data)
        {
            var lon = data.Longitude;
            var lat = data.Latitude;
            
            Console.WriteLine($"longitude: {lon}, latitude, {lat}");
        }*/
    }
}