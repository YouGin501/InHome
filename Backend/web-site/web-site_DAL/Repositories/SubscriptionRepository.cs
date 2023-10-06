using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly WebSiteDbContext _context;

        public SubscriptionRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int entityId)
        {
            try
            {
                var entity = await _context.Subscriptions.FirstOrDefaultAsync(
                    x => x.Id == entityId
                );
                if (entity != null)
                {
                    _context.Subscriptions.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Subscription>> GetAll()
        {
            try
            {
                return await _context.Subscriptions
                    .Include(x => x.Receiver)
                    .Include(x => x.Subscriber)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Subscription?> GetById(int id)
        {
            try
            {
                return await _context.Subscriptions
                    .Include(x => x.Receiver)
                    .Include(x => x.Subscriber)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Subscription> Insert(Subscription entity)
        {
            try
            {
                await _context.Subscriptions.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Subscription> Update(Subscription entity)
        {
            try
            {
                _context.Subscriptions.Update(entity);
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
