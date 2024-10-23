using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScoreManagmentAPI.Models;
using ScoreManagmentAPI.Services;

namespace ScoreManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventWithLayersController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventWithLayersController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: api/EventWithLayers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        {
            return Ok(await _eventService.GetAllEventsAsync());
        }

        // GET: api/EventWithLayers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _eventService.GetEventByIdAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // POST: api/EventWithLayers
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            await _eventService.AddEventAsync(@event);
            return CreatedAtAction(nameof(GetEvent), new { id = @event.EventId }, @event);
        }
    }
}
