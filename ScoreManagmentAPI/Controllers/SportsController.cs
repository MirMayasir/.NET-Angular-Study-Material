using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreManagmentAPI.Models;

namespace ScoreManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly ScoreMonitoringContext _context;

        public SportsController(ScoreMonitoringContext context)
        {
            _context = context;
        }

        [HttpGet("sports")]
        public async Task<ActionResult<IEnumerable<Sport>>> GetSports()
        {
            return await _context.Sports.ToListAsync();
        }
    }
}
