using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly WebSiteDbContext _context;

        public ProjectRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsFromSubscriptions(
            int number,
            int subscribedUserId
        )
        {
            var usersSubscribedTo = _context.Subscriptions
                .Include(x => x.Receiver)
                .Include(x => x.Subscriber)
                .Where(x => x.SubscriberId == subscribedUserId)
                .Select(x => x.Receiver)
                .ToList();

            List<Project> projects = await _context.RealEstates
                .Include(x => x.PhotosUrls)
                .Include(x => x.User)
                .Where(x => usersSubscribedTo.Contains(x.User))
                .OfType<Project>()
                .ToListAsync();

            projects.AddRange(
                await _context.Rents
                    .Include(x => x.PhotosUrls)
                    .Include(x => x.User)
                    .Where(x => usersSubscribedTo.Contains(x.User))
                    .OfType<Project>()
                    .ToListAsync()
            );

            projects.AddRange(
                await _context.Designs
                    .Include(x => x.PhotosUrls)
                    .Include(x => x.User)
                    .Where(x => usersSubscribedTo.Contains(x.User))
                    .OfType<Project>()
                    .ToListAsync()
            );

            return projects.OrderBy(x => x.CreationDate).Take(number);
        }

    }
}
