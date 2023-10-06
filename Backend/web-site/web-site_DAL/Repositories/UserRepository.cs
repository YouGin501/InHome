using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WebSiteDbContext _context;

        public UserRepository(WebSiteDbContext webSiteDbContext)
        {
            _context = webSiteDbContext;
        }

        async public Task<User?> Get(string login, string password)
        {
            return await _context.Users
                .Include(x => x.Comments)
                .Include(x => x.UserLikes)
                .Include(x => x.SubscriberSubscriptions)
                .Include(x => x.ReceiverSubscriptions)
                .Include(x => x.Feedbacks)
                .Include(x => x.Photo)
                .Include(x => x.Documents)
                .FirstOrDefaultAsync(x => x.Email == login && x.Password == password);
        }

        async public Task<User?> GetById(int userId)
        {
            try
            {
                return await _context.Users
                    .Include(x => x.Comments)
                    .Include(x => x.UserLikes)
                    .Include(x => x.SubscriberSubscriptions)
                    .Include(x => x.ReceiverSubscriptions)
                    .Include(x => x.Feedbacks)
                    .Include(x => x.Photo)
                    .Include(x => x.Documents)
                    .FirstOrDefaultAsync(x => x.Id == userId);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
        }

        async public Task Delete(int entityId)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == entityId);
            if (entity != null)
            {
                var userSubscriptions = await _context.Subscriptions
                    .Where(s => s.SubscriberId == entityId)
                    .ToListAsync();
                var userReceivedSubscriptions = await _context.Subscriptions
                    .Where(s => s.ReceiverId == entityId)
                    .ToListAsync();
                var userLikes = await _context.Likes.Where(l => l.UserId == entityId).ToListAsync();
                var userComments = await _context.Comments
                    .Where(c => c.AuthorId == entityId)
                    .ToListAsync();
                var userReviews = await _context.Feedbacks
                    .Where(r => r.WrittenForUserId == entityId)
                    .ToListAsync();

                if (userSubscriptions != null)
                {
                    foreach (var subscription in userSubscriptions)
                    {
                        var subscriptionInDb = _context.Subscriptions.FirstOrDefault(
                            sub => sub.Id == subscription.Id
                        );
                        _context.Subscriptions.Remove(subscriptionInDb);
                    }
                }
                if (userReceivedSubscriptions != null)
                {
                    foreach (var item in userReceivedSubscriptions)
                    {
                        var subscriptionInDb = _context.Subscriptions.FirstOrDefault(
                            sub => sub.Id == item.Id
                        );
                        _context.Subscriptions.Remove(subscriptionInDb);
                    }
                }
                if (userLikes != null)
                {
                    foreach (var item in userLikes)
                    {
                        var likeInDb = _context.Likes.FirstOrDefault(sub => sub.Id == item.Id);
                        _context.Likes.Remove(likeInDb);
                    }
                }
                if (userComments != null)
                {
                    foreach (var item in userComments)
                    {
                        var commentInDb = _context.Comments.FirstOrDefault(
                            sub => sub.Id == item.Id
                        );
                        _context.Comments.Remove(commentInDb);
                    }
                }
                if (userReviews != null)
                {
                    foreach (var item in userReviews)
                    {
                        var reviewInDb = _context.Feedbacks.FirstOrDefault(sub => sub.Id == item.Id);
                        _context.Feedbacks.Remove(reviewInDb);
                    }
                }

                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        async public Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users
                .Include(x => x.Comments)
                .Include(x => x.UserLikes)
                .Include(x => x.SubscriberSubscriptions)
                .Include(x => x.ReceiverSubscriptions)
                .Include(x => x.Feedbacks)
                .Include(x => x.Documents)
                .ToListAsync();
        }

        async public Task<User> Insert(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        async public Task<User> Update(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
