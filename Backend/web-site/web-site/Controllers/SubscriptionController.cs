using Microsoft.AspNetCore.Mvc;
using web_site_BAL.Services;
using web_site_Domain.Models;

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly SubscriptionService _subscriptionService;

        public SubscriptionController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Subscription>>> GetAllSubscriptions()
        {
            var subscriptions = await _subscriptionService.GetAllSubscriptions();
            return Ok(subscriptions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subscription>> GetSubscription([FromRoute] int id)
        {
            var subscription = await _subscriptionService.GetSubscriptionById(id);

            if (subscription == null)
            {
                return NotFound();
            }

            return subscription;
        }

        [HttpPost]
        public async Task<ActionResult> PostSubscription([FromRoute] Subscription subscriptionModel)
        {
            await _subscriptionService.AddSubscription(subscriptionModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubscription([FromRoute] int id, [FromRoute] Subscription subscriptionModel)
        {
            if (id != subscriptionModel.Id)
            {
                return BadRequest();
            }
            try
            {
                await _subscriptionService.UpdateSubscription(subscriptionModel);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription([FromRoute] int id)
        {
            try
            {
                await _subscriptionService.DeleteSubscription(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
