using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using CapstoneProjectAPI.Services;
using CapstoneProjectAPI.Models;

namespace CapstoneProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionWithLayersController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionWithLayersController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        // GET: api/SubscriptionWithLayers
        [HttpGet]
        public async Task<ActionResult<List<Subscription>>> GetAll()
        {
            var subscriptions = await _subscriptionService.GetAllSubscriptionsAsync();
            return Ok(subscriptions);
        }

        // GET: api/SubscriptionWithLayers/{username}
        [HttpGet("{username}")]
        public async Task<ActionResult<Subscription>> GetSubscription(string username)
        {
            var subscription = await _subscriptionService.GetSubscriptionByUsernameAsync(username);
            if (subscription == null)
            {
                return NotFound("Subscription not found.");
            }

            return Ok(subscription);
        }

        // POST: api/SubscriptionWithLayers/subscribe
        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] SubscribeRequest request)
        {
            try
            {
                var result = await _subscriptionService.SubscribeAsync(request.Username, request.PlanType);
                if (result == "User not found." || result == "User is already subscribed.")
                {
                    return BadRequest(result);
                }

                return Ok("Subscription successful.");
            }
            catch (Exception ex)
            {
                // Log the exception (using a logging framework or Console)
                Console.WriteLine(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/SubscriptionWithLayers/unsubscribe
        [HttpPost("unsubscribe")]
        public async Task<IActionResult> Unsubscribe([FromBody] UnsubscribeRequestWithLayers request)
        {
            var result = await _subscriptionService.UnsubscribeAsync(request.Username);
            if (result == "User not found." || result == "No active subscription found.")
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // Define request models
        public class SubscribeRequest
        {
            public string Username { get; set; }
            public string PlanType { get; set; }
        }

        public class UnsubscribeRequestWithLayers
        {
            public string Username { get; set; }
        }
    }
}
