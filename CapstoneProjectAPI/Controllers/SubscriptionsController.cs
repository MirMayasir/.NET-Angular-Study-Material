using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CapstoneProjectAPI.Models;

namespace CapstoneProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsController : ControllerBase
    {
        private readonly CapstoneProjectContext _context;

        public SubscriptionsController(CapstoneProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subscription>>> getAll()
        {
            return await _context.Subscriptions.ToListAsync();
        }
        // GET: api/Subscriptions/{username}
        [HttpGet("{username}")]
        public async Task<ActionResult<Subscription>> GetSubscription(string username)
        {
            var subscription = await _context.Subscriptions
                .Where(s => s.Username == username)
                .FirstOrDefaultAsync();

            if (subscription == null)
            {
                return NotFound("Subscription not found.");
            }

            return Ok(subscription);
        }


        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] SubscriptionRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.Username);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var existingSubscription = await _context.Subscriptions
                .FirstOrDefaultAsync(s => s.Username == request.Username && s.IsSubscribed == true);

            if (existingSubscription != null)
            {
                return BadRequest("User is already subscribed.");
            }

            var subscription = new Subscription
            {
                Username = request.Username,
                IsSubscribed = true,
                SubscriptionDate = DateOnly.FromDateTime(DateTime.UtcNow),
                PlanType = request.PlanType // Weekly, Monthly, Yearly
            };

            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();

            return Ok("Subscription successful.");
        }

        [HttpPost("unsubscribe")]
        public async Task<IActionResult> Unsubscribe([FromBody] UnsubscribeRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.Username);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var subscription = await _context.Subscriptions
                .FirstOrDefaultAsync(s => s.Username == request.Username && s.IsSubscribed == true);

            if (subscription == null)
            {
                return NotFound("No active subscription found.");
            }

            subscription.IsSubscribed = false;
            subscription.UnsubscribeDate = DateOnly.FromDateTime(DateTime.UtcNow);

            _context.Entry(subscription).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Unsubscribed successfully.");
        }



        // Define a request model for Subscription actions
        public class SubscriptionRequest
        {
            public string Username { get; set; }
            public string PlanType { get; set; }
        }
        public class UnsubscribeRequest
        {
            public string Username { get; set; }
        }

    }
}