using System.Dynamic;

namespace BusBoard
{
    public class PostcodeData
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Postcode { get; set; }
    }

    public class PostCodeResponseObj
    {
        public PostcodeData Result { get; set; }
        public int Status { get; set; }
    }
}