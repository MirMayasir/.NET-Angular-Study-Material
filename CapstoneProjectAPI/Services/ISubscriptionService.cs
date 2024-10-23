using CapstoneProjectAPI.Models;

namespace CapstoneProjectAPI.Services
{
    public interface ISubscriptionService
    {
        Task<List<Subscription>> GetAllSubscriptionsAsync();
        Task<Subscription> GetSubscriptionByUsernameAsync(string username);
        Task<string> SubscribeAsync(string username, string planType);
        Task<string> UnsubscribeAsync(string username);
    }
}
