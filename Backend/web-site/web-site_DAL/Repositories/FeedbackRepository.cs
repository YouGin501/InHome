using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly WebSiteDbContext _context;

        public FeedbackRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        async public Task Delete(int entityId)
        {
            try
            {
                var entity = await _context.Feedbacks.FirstOrDefaultAsync(x => x.Id == entityId);
                if (entity != null)
                {
                    _context.Feedbacks.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async public Task<IEnumerable<Feedback>> GetAll(int? writtenForUserId)
        {
            try
            {
                var feedbacks = _context.Feedbacks.AsQueryable();
                if (writtenForUserId != null)
                {
                    feedbacks = feedbacks.Where(x => x.WrittenForUserId == writtenForUserId);
                }

                return await feedbacks
                    .Include(x => x.Author)
                    .ThenInclude(a => a.Photo)
                    .Include(x => x.WrittenForUser)
                    .ThenInclude(u => u.Photo)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        async public Task<IEnumerable<Feedback>> GetAll()
        {
            try
            {
                return await _context.Feedbacks
                    .Include(x => x.Author)
                    .Include(x => x.WrittenForUser)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async public Task<Feedback?> GetById(int id)
        {
            try
            {
                return await _context.Feedbacks
                    .Include(x => x.Author)
                    .Include(x => x.WrittenForUser)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async public Task<Feedback> Insert(Feedback entity)
        {
            try
            {
                await _context.Feedbacks.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async public Task<Feedback> Update(Feedback entity)
        {
            try
            {
                _context.Feedbacks.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
