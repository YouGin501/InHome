using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_BAL.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsFromSubscriptions(int number, int subscribedUserId) {
            return await _projectRepository.GetAllProjectsFromSubscriptions(number, subscribedUserId);
        }
    }
}