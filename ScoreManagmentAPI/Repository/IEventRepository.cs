using ScoreManagmentAPI.Models;

namespace ScoreManagmentAPI.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task AddEventAsync(Event @event);
        Task<bool> EventExistsAsync(int id);
    }
}
