using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TvApi.Data;
using TvApi.Models;

namespace TvApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowsController : Controller
    {
        private readonly ILogger<ShowsController> _logger;
        private readonly TvMazeContext db;

        public ShowsController(ILogger<ShowsController> logger, TvMazeContext context)
        {
            _logger = logger;
            db = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var shows = await db.shows.ToListAsync();
            return Json(await db.shows.ToListAsync());
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShowCast(long? showId)
        {
            var showWithCast = await db.shows.Where(s => s.ShowId == showId)
                 .Include(s => s.Casts)
                 .FirstOrDefaultAsync();
            return Json(showWithCast);
        }
        

    }
}
