using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Please enter a stop code:");
            
            
            void GetBuses(string stopcode)
            {
                var client = new RestClient($"https://api.tfl.gov.uk");
                var request = new RestRequest("StopPoint/{stopcode}/Arrivals", Method.GET)
                    .AddUrlSegment("stopcode", stopcode);
                
                IRestResponse<List<Bus>> response = client.Get<List<Bus>>(request);
                var busList = response.Data.OrderBy(bus=>bus.TimeToStation).ToList();
                
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(i+1 +")");
                    Console.WriteLine("Bus destination: " + busList[i].DestinationName);
                    Console.WriteLine("Bus number: " + busList[i].LineId);
                    if (busList[i].TimeToStation / 60 == 1)
                    {
                        Console.WriteLine("Time til arrival: " + busList[i].TimeToStation/60 + " minute");
                    }
                    else
                    {
                        Console.WriteLine("Time til arrival: " + busList[i].TimeToStation/60 + " minutes");
                    }
                    Console.WriteLine();
                }
            }
            
            GetBuses("490008660N");
            
            
            /*Console.WriteLine("The next five buses are:\n");
            Console.WriteLine();*/

            


        }
    }
}