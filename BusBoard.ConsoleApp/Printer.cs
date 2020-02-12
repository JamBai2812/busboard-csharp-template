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
                bus.PrintDetails();
            }

            Console.WriteLine("===================================");
        }

        public static void TwoStopsNearMe(List<Stop> stopList)
        {
            Console.WriteLine("=================================\nThe Stops nearest to you are:");
            foreach (var stop in stopList.Take(2))
            {
                stop.PrintDetails();
            }
            Console.WriteLine("=================================");
        }
    }
}