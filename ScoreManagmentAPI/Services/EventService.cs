using System.Collections.Generic;
using System.Threading.Tasks;
using ScoreManagmentAPI.Models;
using ScoreManagmentAPI.Repository;
using ScoreManagmentAPI.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _eventRepository.GetAllEventsAsync();
    }

    public async Task<Event> GetEventByIdAsync(int id)
    {
        return await _eventRepository.GetEventByIdAsync(id);
    }

    public async Task AddEventAsync(Event @event)
    {
        await _eventRepository.AddEventAsync(@event);
    }
}
