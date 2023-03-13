using Newtonsoft.Json;
using TvApi.Models;
using TvApi.Utility;

namespace TvApi.Services
{
    public class Crawler
    {
        public static async Task<Show> CrawlShowAsync(long ShowId)
        {
            HttpClient client = new HttpClient();
            string url = "https://api.tvmaze.com/shows/" + ShowId;
            string response = await client.GetStringAsync(url);
            var Show = JsonConvert.DeserializeObject<Show>(response);
            return Show;
        }
        public static async Task<List<CastTemp>> GetCastsAsync(long ShowId)
        {
            HttpClient client = new HttpClient();
            string urlcast = "https://api.tvmaze.com/shows/" + ShowId + "/cast";
            string responseCast = await client.GetStringAsync(urlcast);
            List<CastTemp> Casts = JsonConvert.DeserializeObject<List<CastTemp>>(responseCast);
            return Casts;
        }
    }
}
