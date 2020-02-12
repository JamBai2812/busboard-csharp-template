using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard
{
    public class PostcodeAPI
    {
        private readonly RestClient _client = new RestClient("https://api.postcodes.io");
        
        
        public PostcodeData GetPostCodeData(string postCode)
        {
            var request = new RestRequest($"postcodes/{postCode}", DataFormat.Json);
            var response = _client.Get<PostCodeResponseObj>(request);
            var data = response.Data.Result;
            return data;
        }
        
        
    }
}