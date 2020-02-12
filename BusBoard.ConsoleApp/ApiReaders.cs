using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard
{
    public class ApiReader
    {
        //Fields
        protected RestClient _client { get; set; }
    }


    public class TfLApiReader : ApiReader
    {
        //Constructor
        public TfLApiReader(string baseURL)
        {
            _client = new RestClient(baseURL);
        }
        //Methods

        public IEnumerable<Bus> GetBusesAtStop(string stopcode)
        {
            var request = new RestRequest("StopPoint/{stopcode}/Arrivals", DataFormat.Json)
                .AddUrlSegment("stopcode", stopcode);

            var response = _client.Get<List<Bus>>(request);

            return response.Data.OrderBy(bus => bus.TimeToStation);
        }

        public List<Stop> GetStops(string lat, string lon, string rd)
        {
            var request =
                new RestRequest(
                    $"StopPoint/?stopTypes=NaptanPublicBusCoachTram&radius={rd}&modes=bus&lat={lat}&lon={lon}",
                    Method.GET);
            var response = _client.Get<StopPointsResponse>(request);

            return response.Data.StopPoints;
        }

        public static void PostCodeValidator(string postCode)
        {
            var busManager = new Manager();
            try
            {
                var validatedStopList = busManager.GetStopListNearPostCode(postCode);
                var validator = validatedStopList[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("\nThat postcode is not in the TfL database!\n");
                throw;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("\nYour entry is not a postcode!\n");
                throw;
            }
        }
    }

    public class PostcodesApiReader : ApiReader
    {
        //Constructor
        public PostcodesApiReader(string baseURL)
        {
            _client = new RestClient(baseURL);
        }

        //Methods
        public PostcodeData GetPostCodeData(string postCode)
        {
            var request = new RestRequest($"postcodes/{postCode}", DataFormat.Json);
            var response = _client.Get<PostCodeResponse>(request);
            var data = response.Data.Result;
            return data;
        }
    }
}