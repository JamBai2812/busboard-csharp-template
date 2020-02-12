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
            var tflapi = new TfLApiReader();
            var postapi = new PostcodeAPI();
            
            GetFiveNextBusesFromTwoClosestStops();


            void GetFiveNextBusesFromTwoClosestStops()
            {
                Console.WriteLine("Please enter a postcode:");
                var postCode = Console.ReadLine();

                var data = postapi.GetPostCodeData(postCode);
                var stopList = tflapi.GetStops(data.Latitude, data.Longitude, "300");
                PrintToConsole.StopsNearMe(stopList);

                foreach (var stop in stopList.Take(2))
                {
                    var busList = tflapi.GetBusesAtStop(stop.NaptanId);
                    Console.WriteLine($"\nThe next buses from {stop.CommonName}({stop.StopLetter}) are: ");
                    PrintToConsole.NextFiveBuses(busList);
                }
            }
            
            
            //Eventually just want:
        /*
            Getter.ChooseOption();
            var inputPostcode = Console.ReadLine();
            
            
            
            
            */
            
            
        }   
        

    }
}