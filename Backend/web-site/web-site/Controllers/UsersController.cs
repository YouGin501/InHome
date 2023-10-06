using Microsoft.AspNetCore.Mvc;
using web_site.Controllers.Models;
using web_site_BAL.Contracts;
using web_site_BAL.Services;
using web_site_Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;
        public UsersController(IUserService userService, IWebHostEnvironment env)
        {
            _userService = userService;
            _env = env;
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<User>> LoginUser(LoginModel loginModel)
        {
            var user = await _userService.LoginUser(loginModel.Login, loginModel.Password);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [Route("Registration")]
        [HttpPost]
        public async Task<ActionResult<User>> RegistrUser(User user)
        {
            var registeredUser = await _userService.AddUser(user);

            if (registeredUser == null)
            {
                return NotFound();
            }

            return registeredUser;
        }

        // GET: api/<UserModelsController>
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        // GET api/<UserModelsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser([FromRoute] int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST api/<UserModelsController>
        [HttpPost]
        public async Task<ActionResult> PostUser([FromRoute] User userModel)
        {
            await _userService.AddUser(userModel);
            return Ok();
        }

        // PUT api/<UserModelsController>/5       [FromBody]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutUserAsync([FromBody] User user)
        {
            try
            {
                if (user.Id != user.Id)
                {
                    return BadRequest();
                }

                await _userService.UpdateUser(user.Id, user);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        // DELETE api/<UserModelsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
