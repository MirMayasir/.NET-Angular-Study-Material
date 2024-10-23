using CapstoneProjectAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using CapstoneProjectAPI.Repositery;

namespace CapstoneProjectAPI.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly CapstoneProjectContext _context;

        public SubscriptionRepository(CapstoneProjectContext context)
        {
            _context = context;
        }

        public async Task<List<Subscription>> GetAllSubscriptionsAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<Subscription> GetSubscriptionByUsernameAsync(string username)
        {
            return await _context.Subscriptions
                .Where(s => s.Username == username)
                .FirstOrDefaultAsync();
        }

        public async Task AddSubscriptionAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubscriptionAsync(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task<Subscription> GetActiveSubscriptionByUsernameAsync(string username)
        {
            return await _context.Subscriptions
                .FirstOrDefaultAsync(s => s.Username == username && s.IsSubscribed == true);
        }
    }
}
