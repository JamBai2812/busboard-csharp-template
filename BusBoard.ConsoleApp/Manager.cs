using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard
{
    public class Manager
    {
        //Fields (instances of api readers)
        private TfLApiReader tflapi = new TfLApiReader("https://api.tfl.gov.uk");
        private PostcodesApiReader postapi = new PostcodesApiReader("https://api.postcodes.io");

        //Methods
        
        public string GetUserPostCode()
        {
            Console.WriteLine("Please enter a postcode:");
            var postCode = Console.ReadLine();
            return postCode;
        }
        public List<Stop> GetStopListNearPostCode(string postCode)
        {
            var data = postapi.GetPostCodeData(postCode);
            var stopList = tflapi.GetStops(data.Latitude, data.Longitude, "300");
            return stopList;
        }
        public void GetFiveNextBusesFromTwoClosestStops(List<Stop> stopList)
        {
            PrintToConsole.TwoStopsNearMe(stopList);
            foreach (var stop in stopList.Take(2))
            {
                var busList = tflapi.GetBusesAtStop(stop.NaptanId);
                Console.WriteLine($"\nThe next buses from {stop.CommonName}({stop.StopLetter}) are: ");
                PrintToConsole.NextFiveBuses(busList);
            }
        }

       
    }
}