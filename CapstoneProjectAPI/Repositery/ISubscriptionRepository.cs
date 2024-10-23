using CapstoneProjectAPI.Models;

namespace CapstoneProjectAPI.Repositery
{
    public interface ISubscriptionRepository
    {
        Task<List<Subscription>> GetAllSubscriptionsAsync();
        Task<Subscription> GetSubscriptionByUsernameAsync(string username);
        Task AddSubscriptionAsync(Subscription subscription);
        Task UpdateSubscriptionAsync(Subscription subscription);
        Task<Subscription> GetActiveSubscriptionByUsernameAsync(string username);
    }
}
