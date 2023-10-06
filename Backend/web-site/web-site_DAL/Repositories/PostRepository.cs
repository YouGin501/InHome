using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Enums;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly WebSiteDbContext _context;

        public PostRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int entityId)
        {
            try
            {
                var entity = await _context.Posts.FirstOrDefaultAsync(x => x.Id == entityId);
                if (entity != null)
                {
                    _context.Posts.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            try
            {
                return await _context.Posts
                    .Include(x => x.Photos)
                    .Include(x => x.Location)
                    .Include(x => x.PostLikes)
                    .Include(x => x.User)
                    .Include(x => x.Comments)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Post>> GetAll(int? userId)
        {
            try
            {
                var posts = _context.Posts.AsQueryable();
                if (userId != null)
                {
                    posts = posts.Where(x => x.UserId == userId);
                }
                return await posts
                    .Include(x => x.Photos)
                    .Include(x => x.Location)
                    .Include(x => x.PostLikes)
                    .Include(x => x.User)
                    .Include(x => x.Comments)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Post?> GetById(int id)
        {
            try
            {
                return await _context.Posts
                    .Include(x => x.Photos)
                    .Include(x => x.Location)
                    .Include(x => x.PostLikes)
                    .Include(x => x.User)
                    .Include(x => x.Comments)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Post>> GetPostsForUser(
            int userId,
            string? country,
            UserType? userType
        )
        {
            var usersSubscribedTo = _context.Subscriptions
                .Include(x => x.Receiver)
                .Include(x => x.Subscriber)
                .Where(x => x.SubscriberId == userId)
                .Select(x => x.Receiver)
                .ToList();

            var posts = _context.Posts
                .Include(x => x.Photos)
                .Include(x => x.Location)
                .Include(x => x.PostLikes)
                .Include(x => x.User)
                .Include(x => x.Comments)
                .AsQueryable();

            if (!String.IsNullOrEmpty(country))
            {
                posts = posts.Where(x => x.Location.Country == country);
            }
            if (userType != null)
            {
                posts = posts.Where(x => x.User.UserType == userType);
            }

            return await posts
                .Where(x => usersSubscribedTo.Contains(x.User))
                .OrderBy(x => x.CreationDate)
                .ToListAsync();
        }

        public async Task<Post> Insert(Post entity)
        {
            try
            {
                await _context.Posts.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Post> Update(Post entity)
        {
            try
            {
                _context.Posts.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
