using System;
using System.Dynamic;

namespace BusBoard
{
    public class PostCodeResponse
    {
        //Properties
        public PostcodeData Result { get; set; }
        public int Status { get; set; }
    }

    public class PostcodeData
    {
        //Properties
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Postcode { get; set; }
    }
}