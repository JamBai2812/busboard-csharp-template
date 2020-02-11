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
            
            tflapi.GetStops("51.509219", "-0.035665", "5000");
            
            //Console.WriteLine("Please enter a stop code:");
            //var stopCode = GetStopCode(Console.ReadLine());
            
            
            //var busList = tflapi.GetBusesAtStop("490008660N");
            
            
            
            //PrintToConsole.NextFiveBuses(busList);
            
            
            
            
        }   
        

    }
}