using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    public class PrintToConsole
    {
        public static void NextFiveBuses(IEnumerable<Bus> busList)
        {
            Console.WriteLine("==========================================\nThe next five buses are:\n");
            foreach (var bus in busList.Take(5))
            {
                // Console.WriteLine($"\n {i+1})");
                Console.WriteLine("Bus destination: " + bus.DestinationName);
                Console.WriteLine("Bus number: " + bus.LineId);
                if (bus.TimeToStation / 60 == 1)
                {
                    Console.WriteLine("Time til arrival: " + bus.TimeToStation / 60 + " minute");
                }
                else
                {
                    Console.WriteLine("Time til arrival: " + bus.TimeToStation / 60 + " minutes");
                }
            }
            Console.WriteLine("\n=========================================");
        }
    }
}