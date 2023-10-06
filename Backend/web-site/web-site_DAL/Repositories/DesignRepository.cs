using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class DesignRepository : IDesignRepository
    {
        private readonly WebSiteDbContext _context;

        public DesignRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int entityId)
        {
            try
            {
                var entity = await _context.Designs.FirstOrDefaultAsync(x => x.Id == entityId);
                if (entity != null)
                {
                    _context.Designs.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        async public Task<IEnumerable<Design>> GetAll(
            DateTime? startDate,
            DateTime? endDate,
            int? numberOfRecords,
            bool? isOnlyLiked,
            int? userId
        )
        {
            try
            {
                var designs = _context.Designs.AsQueryable();
                if (startDate != null)
                {
                    designs = designs.Where(x => x.CreationDate >= (DateTime)startDate);
                }
                if (endDate != null)
                {
                    designs = designs.Where(x => x.CreationDate <= (DateTime)endDate);
                }
                if (isOnlyLiked != null)
                {
                    designs = designs.Where(x => x.Likes != null).OrderBy(x => x.Likes.Count);
                }
                if (numberOfRecords != null)
                {
                    designs = designs.Take((int)numberOfRecords);
                }
                if (userId != null)
                {
                    designs = designs.Where(x => x.UserId == userId);
                }

                return await designs
                    .Include(x => x.User)
                    .Include(x => x.PhotosUrls)
                    .Include(x => x.Likes)
                    .Include(x => x.Location)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Design>> GetAll()
        {
            try
            {
                return await _context.Designs
                    .Include(x => x.User)
                    .Include(x => x.PhotosUrls)
                    .Include(x => x.Likes)
                    .Include(x => x.Location)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        async public Task<Design?> GetById(int designId)
        {
            try
            {
                return await _context.Designs
                    .Include(x => x.User)
                    .Include(x => x.PhotosUrls)
                    .Include(x => x.Likes)
                    .Include(x => x.Location)
                    .FirstOrDefaultAsync(x => x.Id == designId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Design> Insert(Design entity)
        {
            try
            {
                await _context.Designs.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Design> Update(Design entity)
        {
            try
            {
                _context.Designs.Update(entity);
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
