using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class PostCategoryRepository : IPostCategoryRepository
    {
        private readonly WebSiteDbContext _context;

        public PostCategoryRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        async public Task<PostCategory> Insert(PostCategory entity)
        {
            try
            {
                await _context.PostCategories.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PostCategory>> GetAll()
        {
            try
            {
                return await _context.PostCategories.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PostCategory?> GetById(int id)
        {
            try
            {
                return await _context.PostCategories.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PostCategory> Update(PostCategory entity)
        {
            try
            {
                _context.PostCategories.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int entityId)
        {
            try
            {
                var entity = await _context.PostCategories.FirstOrDefaultAsync(x => x.Id == entityId);
                if (entity != null)
                {
                    _context.PostCategories.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
