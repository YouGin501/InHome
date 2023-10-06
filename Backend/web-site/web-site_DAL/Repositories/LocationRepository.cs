using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly WebSiteDbContext _context;

        public LocationRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        async public Task<Location> Insert(Location entity)
        {
            try
            {
                await _context.Locations.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Location>> GetAll()
        {
            try
            {
                return await _context.Locations.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Location?> GetById(int id)
        {
            try
            {
                return await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Location> Update(Location entity)
        {
            try
            {
                _context.Locations.Update(entity);
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
                var entity = await _context.Locations.FirstOrDefaultAsync(x => x.Id == entityId);
                if (entity != null)
                {
                    _context.Locations.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async public Task<IEnumerable<Location>> GetAll(string? city, string? country, string? address)
        {
            try
            {
                var locations = _context.Locations.AsQueryable();
                if (city != null)
                {
                    locations = locations.Where(x => x.City == city);
                }
                if (address != null)
                {
                    locations = locations.Where(x => x.Address == address);
                }
                if (country != null)
                {
                    locations = locations.Where(x => x.Country == country);
                }
                return await locations.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
