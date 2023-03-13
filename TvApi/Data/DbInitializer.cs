/*
 * Migrations instead of "DbInitializer" like this so that the Database is created for only one time and maintained 
 * automatically instead of dropping and then creating the Database everytime the program start, this is done for demo purposes
*/
using System.Diagnostics;
using TvApi.Models;
using TvApi.Services;
using TvApi.Utility;


namespace TvApi.Data
{
    public static class DbInitializer
    {
        static List<List<Cast>> listedCasts;
        static List<Show> listedShows;
        public static async Task InitializeAsync(TvMazeContext context)
        {
            listedCasts = new List<List<Cast>>();
            listedShows = new List<Show>();
            for (long i= 1;i < 10; i++)
            {
                long ShowId = i;
                Show show = await Crawler.CrawlShowAsync(ShowId);
                listedShows.Add(show);
                List<CastTemp> tempCasts = await Crawler.GetCastsAsync(ShowId);
                List<Cast> casts = CastTemp.TempCastToCast(tempCasts, ShowId);
                listedCasts.Add(casts);
            }
            context.Database.EnsureCreated();

            if (context.shows.Any())
            {
                return;   // DB has been seeded
            }

            
            foreach (Show s in listedShows)
            {
                await context.shows.AddAsync(s);
            }
            await context.SaveChangesAsync();

            foreach (List<Cast> castsList in listedCasts)
            {
                foreach(Cast cast in castsList)
                {
                    await context.casts.AddAsync(cast);
                }

            }
        }
    }
}
