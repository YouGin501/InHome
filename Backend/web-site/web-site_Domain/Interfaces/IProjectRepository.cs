using web_site_Domain.Models;

namespace web_site_Domain.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsFromSubscriptions(int number, int subscribedUserId);
    }
}