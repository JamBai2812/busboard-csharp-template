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
            var busManager = new Manager();
            var postCode = busManager.GetUserPostCode();
            TfLApiReader.PostCodeValidator(postCode);
            var stopList = busManager.GetStopListNearPostCode(postCode);
            busManager.GetFiveNextBusesFromTwoClosestStops(stopList);
        }
    }
}