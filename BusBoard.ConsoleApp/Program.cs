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
            try
            {
                var busManager = new Manager();
                var postCode = busManager.GetUserPostCode();
                var stopList = busManager.GetStopListNearPostCode(postCode);
                busManager.GetFiveNextBusesFromTwoClosestStops(stopList);
            }
            catch (Exception e)
            {
                Console.WriteLine("That Postcode does not exist in the TfL database.");
            }
            




            
        }
    }
}