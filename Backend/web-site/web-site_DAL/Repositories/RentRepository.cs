using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class RentRepository : IRentRepository
    {
        private readonly WebSiteDbContext _context;

        public RentRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        async public Task<IEnumerable<Rent>> GetAll(
            DateTime? startDate,
            DateTime? endDate,
            int? numberOfRecords,
            bool? isOnlyLiked,
            int? userId
        )
        {
            var rents = _context.Rents.AsQueryable();
            if (startDate != null)
            {
                rents = rents.Where(x => x.CreationDate >= (DateTime)startDate); //.ToList();
            }
            if (endDate != null)
            {
                rents = rents.Where(x => x.CreationDate <= (DateTime)endDate); //.ToList();
            }
            if (isOnlyLiked != null)
            {
                rents = rents.Where(x => x.Likes != null).OrderBy(x => x.Likes.Count); //.ToList();
            }
            if (numberOfRecords != null)
            {
                rents = rents.Take((int)numberOfRecords); //.ToList();
            }
            if (userId != null)
            {
                rents = rents.Where(x => x.UserId == userId);
            }

            return await rents
                .Include(x => x.User)
                .Include(x => x.PhotosUrls)
                .Include(x => x.Likes)
                .ToListAsync();
        }

        async public Task<Rent?> GetById(int id)
        {
            return await _context.Rents
                .Include(x => x.User)
                .Include(x => x.Likes)
                .Include(x => x.Location)
                .Include(x => x.PhotosUrls)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Delete(int entityId)
        {
            try
            {
                var entity = await _context.Rents.FirstOrDefaultAsync(x => x.Id == entityId);
                if (entity != null)
                {
                    _context.Rents.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Rent>> GetAll()
        {
            return await _context.Rents
                .Include(x => x.User)
                .Include(x => x.Likes)
                .Include(x => x.Location)
                .Include(x => x.PhotosUrls)
                .ToListAsync();
        }

        public async Task<Rent> Insert(Rent entity)
        {
            try
            {
                await _context.Rents.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Rent> Update(Rent entity)
        {
            try
            {
                _context.Rents.Update(entity);
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
