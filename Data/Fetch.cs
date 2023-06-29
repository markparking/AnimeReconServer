using Newtonsoft.Json.Linq;
using RestSharp;
using AnimeReconServer.Data;
using Newtonsoft.Json;

namespace AnimeReconServer.Data
{
    public class Fetch
    {
        public class API
        {
            public int id { get; set; }
            public string title { get; set; }
            public MainPicture main_picture { get; set; }
            public int rank { get; set; }
            public double mean { get; set; }
            public Titles alternative_titles { get; set; }
            public string synopsis { get; set; }

        }

        public class Titles
        {
            public string en { get; set; }
            public string jp { get; set; }
        }

        public class MainPicture
        {
            public string medium { get; set; }
            public string large { get; set; }
        }

        public class APIItem
        {
            public API node { get; set; }
        }

        public class APIResponse
        {
            public List<APIItem> data { get; set; }
            public Paging paging { get; set; }
        }

        public class Paging
        {
            public string next { get; set; }
        }

        public class FetchApi
        {
            public static APIResponse Fetch()
            {
                RestClient client = new RestClient("https://api.myanimelist.net/v2/anime?q=one&limit=16&fields=rank,mean,alternative_titles,synopsis");
                RestRequest req = new RestRequest();
                req.AddHeader("X-MAL-CLIENT-ID", "39f2ef8e9dca31929cc161e16ba38024");
                RestResponse res = client.Execute(req);
                var json = res.Content;

                // Deserialize the JSON into an APIResponse object
                return JsonConvert.DeserializeObject<APIResponse>(json);
            }

            public static List<API> GetItems()
            {
                APIResponse aPIResponse = Fetch();
                List<APIItem> items = new List<APIItem>();
                foreach (APIItem item in aPIResponse.data)
                {
                    items.Add(item);
                }
                List<API> result = new List<API>();
                foreach (APIItem item in items)
                {
                    result.Add(item.node);
                }

                return result;
            }
        }
    }
}
