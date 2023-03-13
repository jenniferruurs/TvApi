using Newtonsoft.Json;
using System.Linq;
using TvApi.Models;

namespace TvApi.Utility
{
    public class CastTemp
    {
        [JsonProperty("id")]
        public long CastId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }



        public static List<Cast> TempCastToCast(List<CastTemp> obj, long showId)
        {
            List<Cast> listedCasts = new List<Cast>();
            foreach (CastTemp temp in obj)
            {
                Cast output = new Cast() { CastId = temp.CastId, Name = temp.Name, Birthday = temp.Birthday, ShowId = showId };
                listedCasts.Add(output);
            }
            
            return listedCasts;
        }
    }


}


/*
 * 
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var shows = await db.shows.ToListAsync();
            return Json(await db.shows.ToListAsync());
        }
*/