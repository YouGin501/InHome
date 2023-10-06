using Microsoft.AspNetCore.Mvc;
using web_site_BAL.Services;
using web_site_Domain.Models;

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentsController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetAllComments()
        {
            var comments = await _commentService.GetAllComments();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment([FromRoute] int id)
        {
            var comment = await _commentService.GetCommentById(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        [HttpPost]
        public async Task<ActionResult> PostComment([FromRoute] Comment commentModel)
        {
            await _commentService.AddComment(commentModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment([FromRoute] int id, [FromRoute] Comment commentModel)
        {
            if (id != commentModel.Id)
            {
                return BadRequest();
            }

            try
            {
                await _commentService.UpdateComment(commentModel);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            try
            {
                await _commentService.DeleteComment(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
