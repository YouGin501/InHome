using Microsoft.AspNetCore.Mvc;
using web_site_BAL.Contracts;
using web_site_Domain.Models;

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbacksController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Feedback>>> GetAll(int? writtenForUserId)
        {
            try
            {
                var feedbacks = await _feedbackService.GetAll(writtenForUserId);
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Feedback>> GetDesign([FromRoute] int id)
        {
            try
            {
                var feedback = await _feedbackService.GetById(id);

                if (feedback == null)
                {
                    return StatusCode(500, "Feedback with such id does not exists");
                }

                return feedback;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Feedback>> AddFeedback([FromBody] Feedback feedbackModel)
        {
            try
            {
                var result = await _feedbackService.Add(feedbackModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Feedback>> UpdateFeedback([FromBody] Feedback feedbackModel)
        {
            try
            {
                var result = await _feedbackService.Update(feedbackModel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
