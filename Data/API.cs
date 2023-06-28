using Newtonsoft.Json.Linq;
using RestSharp;
using static System.Net.WebRequestMethods;

namespace AnimeReconServer.Data
{
    public class API
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string PictureURL { get; set; }
        public int Rank { get; set; }
        public double Mean { get; set; }
        public string EN_Title { get; set; }
        public string Synopsis { get; set; }
    }
}
