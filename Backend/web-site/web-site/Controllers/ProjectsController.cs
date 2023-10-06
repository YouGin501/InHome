using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web_site_BAL.Services;
using web_site_Domain.Models;

namespace web_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _projectService;
        private readonly IWebHostEnvironment _env;

        public ProjectsController(ProjectService projectService, IWebHostEnvironment env)
        {
            _projectService = projectService;
            _env = env;
        }

        [Route ("GetAllProjectsFromSubscriptions")]
        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetAllProjectsFromSubscriptions(int number, int subscribedUserId)
        {
            var posts = await _projectService.GetAllProjectsFromSubscriptions(number, subscribedUserId);
            return Ok(posts);
        }
    }
}