using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly WebSiteDbContext _context;

        public LikeRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        async public Task<Like> Insert(Like entity)
        {
            Like? alreadyExisted;
            if ( entity.PostId != null)
            {
                alreadyExisted = _context.Likes.FirstOrDefault(
                    x => x.PostId == entity.PostId && x.UserId == entity.UserId
                );
            }
            else
            {
                alreadyExisted = _context.Likes.FirstOrDefault(
                    x => x.ProjectId == entity.ProjectId && x.UserId == entity.UserId
                );
            }

            if (alreadyExisted == null)
            {
                await _context.Likes.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Likes.Remove(alreadyExisted);
                await _context.SaveChangesAsync();
                entity = null;
            }
            return entity;
        }

        async public Task<IEnumerable<Like>> GetAll(int? userId)
        {
            try
            {
                var likes = _context.Likes.AsQueryable();
                if (userId != null)
                {
                    likes = likes.Where(x => x.UserId == userId);
                }
                return await likes
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

        public async Task<IEnumerable<Like>> GetAll()
        {
            try
            {
                return await _context.Likes
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

        public async Task<Like?> GetById(int id)
        {
            try
            {
                return await _context.Likes
                    .Include(x => x.User)
                    .Include(x => x.Post)
                    .Include(x => x.Project)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Like> Update(Like entity)
        {
            try
            {
                _context.Likes.Update(entity);
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
                var entity = await _context.Likes.FirstOrDefaultAsync(x => x.Id == entityId);
                if (entity != null)
                {
                    _context.Likes.Remove(entity);
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
