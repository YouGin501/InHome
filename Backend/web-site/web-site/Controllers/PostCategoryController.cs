using Microsoft.AspNetCore.Mvc;
using web_site_BAL.Services;
using web_site_Domain.Models;

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCategoryController : ControllerBase
    {
        private readonly PostCategoryService _postCategoryService;

        public PostCategoryController(PostCategoryService postCategoryService)
        {
            _postCategoryService = postCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostCategory>>> GetAllPostCategories()
        {
            var postCategories = await _postCategoryService.GetAllPostCategories();
            return Ok(postCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostCategory>> GetPostCategory([FromRoute] int id)
        {
            var postCategory = await _postCategoryService.GetPostCategoryById(id);

            if (postCategory == null)
            {
                return NotFound();
            }

            return postCategory;
        }

        [HttpPost]
        public async Task<ActionResult> PostPostCategory([FromRoute] PostCategory postCategoryModel)
        {
            await _postCategoryService.AddPostCategory(postCategoryModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostCategory([FromRoute] int id, [FromRoute] PostCategory postCategoryModel)
        {
            if (id != postCategoryModel.Id)
            {
                return BadRequest();
            }

            try
            {
                await _postCategoryService.UpdatePostCategory(postCategoryModel);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostCategory([FromRoute] int id)
        {
            try
            {
                await _postCategoryService.DeletePostCategory(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
