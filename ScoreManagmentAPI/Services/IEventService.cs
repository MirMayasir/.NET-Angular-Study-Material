using ScoreManagmentAPI.Models;

namespace ScoreManagmentAPI.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task AddEventAsync(Event @event);
    }
}
