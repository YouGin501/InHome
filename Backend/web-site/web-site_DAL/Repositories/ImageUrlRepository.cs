using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class ImageUrlRepository : IImageUrlRepository
    {
        private readonly WebSiteDbContext _context;

        public ImageUrlRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int entityId)
        {
            try
            {
                var entity = await _context.ImageUrls.FirstOrDefaultAsync(x => x.Id == entityId);
                if (entity != null)
                {
                    _context.ImageUrls.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async public Task<IEnumerable<ImageUrl>> GetAll()
        {
            try
            {
                return await _context.ImageUrls
                    .Include(x => x.User)
                    .Include(x => x.Post)
                    .Include(x => x.Project)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async public Task<ImageUrl?> GetById(int designId)
        {
            try
            {
                return await _context.ImageUrls
                    .Include(x => x.User)
                    .Include(x => x.Post)
                    .Include(x => x.Project)
                    .FirstOrDefaultAsync(x => x.Id == designId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ImageUrl> Insert(ImageUrl entity)
        {
            try
            {
                await _context.ImageUrls.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ImageUrl> Update(ImageUrl entity)
        {
            try
            {
                _context.ImageUrls.Update(entity);
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
