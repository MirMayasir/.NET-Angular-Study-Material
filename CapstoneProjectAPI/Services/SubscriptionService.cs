using CapstoneProjectAPI.Models;
using CapstoneProjectAPI.Repositery;
using CapstoneProjectAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapstoneProjectAPI.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;  // Assuming a UserRepository exists for user-related operations

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IUserRepository userRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Subscription>> GetAllSubscriptionsAsync()
        {
            return await _subscriptionRepository.GetAllSubscriptionsAsync();
        }

        public async Task<Subscription> GetSubscriptionByUsernameAsync(string username)
        {
            return await _subscriptionRepository.GetSubscriptionByUsernameAsync(username);
        }

        public async Task<string> SubscribeAsync(string username, string planType)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username); // Assuming a UserRepository method
            if (user == null)
            {
                return "User not found.";
            }

            var existingSubscription = await _subscriptionRepository.GetActiveSubscriptionByUsernameAsync(username);
            if (existingSubscription != null)
            {
                return "User is already subscribed.";
            }

            var newSubscription = new Subscription
            {
                Username = username,
                IsSubscribed = true,
                SubscriptionDate = DateOnly.FromDateTime(DateTime.UtcNow),
                PlanType = planType
            };

            await _subscriptionRepository.AddSubscriptionAsync(newSubscription);
            return "Subscription successful.";
        }

        public async Task<string> UnsubscribeAsync(string username)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return "User not found.";
            }

            var subscription = await _subscriptionRepository.GetActiveSubscriptionByUsernameAsync(username);
            if (subscription == null)
            {
                return "No active subscription found.";
            }

            subscription.IsSubscribed = false;
            subscription.UnsubscribeDate = DateOnly.FromDateTime(DateTime.UtcNow);

            await _subscriptionRepository.UpdateSubscriptionAsync(subscription);
            return "Unsubscribed successfully.";
        }
    }
}
