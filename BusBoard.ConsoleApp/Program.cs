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
                var client = new RestClient($"https://api.tfl.gov.uk/StopPoint/{stopcode}/Arrivals");
                client.Authenticator = new HttpBasicAuthenticator("0a23312b", "7eac821c843820611cbd430e59853815");
            
                var request = new RestRequest(Method.GET);
                
                IRestResponse<List<Bus>> response = client.Get<List<Bus>>(request);
                var busList = response.Data.OrderBy(o=>o.TimeToStation).ToList();
                
                


                foreach (Bus bus in busList)
                {
                    Console.WriteLine("Bus destination: " + bus.DestinationName);
                    Console.WriteLine("Bus ID"+bus.VehicleId);
                    Console.WriteLine("Time til arrival: "+ bus.TimeToStation);
                }

                var nextFiveBuses = new List<Bus>();
                

                /*foreach (var header in response.Headers)
                {
                   Console.WriteLine(header); 
                }

                Console.WriteLine(response.Headers);*/

                /*foreach (var bus in response)
                {
                    Console.WriteLine(response);
                }*/

            }
            
            GetBuses("490008660N");
            
            
            /*Console.WriteLine("The next five buses are:\n");
            Console.WriteLine();*/

            


        }
    }
}