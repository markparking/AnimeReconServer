using Newtonsoft.Json.Linq;
using RestSharp;
using AnimeReconServer.Data;

namespace AnimeReconServer.Data
{
    public class Fetch
    {
        public static API FetchData()
        {
            RestClient client = new("https://api.myanimelist.net/v2/anime/10357?fields=rank,mean,alternative_titles,synopsis");
            RestRequest req = new();
            //req.AddHeader("Content-Type", "application/json");

            req.AddHeader("X-MAL-CLIENT-ID", "39f2ef8e9dca31929cc161e16ba38024");

            RestResponse res = client.Execute(req);
            // System.Diagnostics.Debug.WriteLine(res.Content);
            // Console.WriteLine(res.Content);
            JObject json = JObject.Parse(res.Content);
            dynamic data = json;
            API api = new API();
            api.ID = data.id;
            api.Title = data.title;
            api.PictureURL = data.main_picture.large;
            api.Rank = data.rank;
            api.Mean = data.mean;
            api.EN_Title = data.alternative_titles.en;
            api.Synopsis = data.synopsis;
            return api;
        }
    }
}
