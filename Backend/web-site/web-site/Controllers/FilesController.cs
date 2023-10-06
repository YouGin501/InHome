using Microsoft.AspNetCore.Mvc;
using web_site.Controllers.Models;
using web_site_BAL.Contracts;

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly IRentService _rentService;
        private readonly IRealEstateService _realEstateService;

        private readonly IResidentialComplexService _residentialComplexService;

        public FilesController(
            IUserService userService,
            IPostService postService,
            IRentService rentService,
            IRealEstateService realEstateService,
            IResidentialComplexService residentialComplexService
        )
        {
            _userService = userService;
            _postService = postService;
            _rentService = rentService;
            _realEstateService = realEstateService;
            _residentialComplexService = residentialComplexService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(List<IFormFile> files, int userId)
        {
            try
            {
                await _userService.AddDocuments(files, userId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(
            [FromBody] DocumentsRequest documents,
            [FromRoute] int id
        )
        {
            try
            {
                bool result = await _userService.DeleteDocument(id, documents.Documents.ToList());
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(500, "Something went wrong");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [Route("updateUserPhoto/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateUserPhoto(
            [FromForm] IFormFile photo,
            [FromRoute] int id
        )
        {
            try
            {
                await _userService.UpdatePhoto(photo, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [Route("addPostPhotos/{id}")]
        [HttpPost]
        public async Task<IActionResult> AddPostPhotos(
            [FromForm] List<IFormFile> photos,
            [FromRoute] int id
        )
        {
            try
            {
                await _postService.AddPostPhotos(photos, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [Route("addRentPhotos/{id}")]
        [HttpPost]
        public async Task<IActionResult> AddRentPhotos(
            [FromForm] List<IFormFile> photos,
            [FromRoute] int id
        )
        {
            try
            {
                await _rentService.AddRentPhotos(photos, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [Route("addRealEstatePhotos/{id}")]
        [HttpPost]
        public async Task<IActionResult> AddRealEstatePhotos(
            [FromForm] List<IFormFile> photos,
            [FromRoute] int id
        )
        {
            try
            {
                await _realEstateService.AddRealEstatePhotos(photos, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        [Route("addResedentialComplexPhotos/{id}")]
        [HttpPost]
        public async Task<IActionResult> AddResidentialComplexPhotos(
            [FromForm] List<IFormFile> photos,
            [FromRoute] int id
        )
        {
            try
            {
                await _residentialComplexService.AddResidentialComplexPhotos(photos, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
