using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly WebSiteDbContext _context;

        public CommentRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int entityId)
        {
            try
            {
                var entity = await _context.Comments.FirstOrDefaultAsync(x => x.Id == entityId);
                if (entity != null)
                {
                    _context.Comments.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            try
            {
                return await _context.Comments
                    .Include(x => x.Author)
                    .Include(x => x.Post)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Comment?> GetById(int id)
        {
            try
            {
                return await _context.Comments
                    .Include(x => x.Author)
                    .Include(x => x.Post)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Comment> Insert(Comment entity)
        {
            try
            {
                await _context.Comments.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Comment> Update(Comment entity)
        {
            try
            {
                _context.Comments.Update(entity);
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
