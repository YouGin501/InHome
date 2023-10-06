using Microsoft.AspNetCore.Mvc;
using web_site_BAL.Contracts;
using web_site_BAL.Services;
using web_site_Domain.Enums;
using web_site_Domain.Models;

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllPosts(int? userId)
        {
            var posts = await _postService.GetAllPosts(userId);
            return Ok(posts);
        }

        [Route ("GetPostsForUser")]
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllPostsForUser(int userId, string? country, UserType? userType)
        {
            var posts = await _postService.GetAllPostsForUser(userId, country, userType);
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost([FromRoute] int id)
        {
            var post = await _postService.GetPostById(id);

            if (post == null)
            {
                return NotFound();
            }

            return post;
        }

        [HttpPost]
        public async Task<ActionResult<Post>> PostPost([FromBody] Post post)
        {
            return await _postService.AddPost(post);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Post>>  PutPost([FromRoute] int id, [FromBody] Post postModel)
        {
            if (id != postModel.Id)
            {
                return BadRequest();
            }

            try
            {
                return await _postService.UpdatePost(id, postModel);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            try
            {
                await _postService.DeletePost(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
