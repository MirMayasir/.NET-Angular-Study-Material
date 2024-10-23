using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ScoreManagmentAPI.Models;
using ScoreManagmentAPI.Repository;

public class EventRepository : IEventRepository
{
    private readonly ScoreMonitoringContext _context;

    public EventRepository(ScoreMonitoringContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _context.Events.ToListAsync();
    }

    public async Task<Event> GetEventByIdAsync(int id)
    {
        return await _context.Events.FindAsync(id);
    }

    public async Task AddEventAsync(Event @event)
    {
        await _context.Events.AddAsync(@event);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> EventExistsAsync(int id)
    {
        return await _context.Events.AnyAsync(e => e.EventId == id);
    }
}
