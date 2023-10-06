using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class ResidentialComplexRepository : IResidentialComplexRepository
    {
        private readonly WebSiteDbContext _context;

        public ResidentialComplexRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int entityId)
        {
            try
            {
                var entity = await _context.ResidentialComplexes.FirstOrDefaultAsync(
                    x => x.Id == entityId
                );
                if (entity != null)
                {
                    _context.ResidentialComplexes.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ResidentialComplex>> GetAll(int? userId)
        {
            try
            {
                var complexes = _context.ResidentialComplexes.AsQueryable();
                if (userId != null)
                {
                    complexes = complexes.Where(x => x.UserId == userId);
                }
                return await complexes
                    .Include(x => x.Apartments)
                    .Include(x => x.Location)
                    .Include(x => x.PhotoUrls)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<ResidentialComplex>> GetAll()
        {
            try
            {
                return await _context.ResidentialComplexes
                    .Include(x => x.Apartments)
                    .Include(x => x.Location)
                    .Include(x => x.PhotoUrls)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResidentialComplex?> GetById(int id)
        {
            try
            {
                return await _context.ResidentialComplexes
                    .Include(x => x.Apartments)
                    .Include(x => x.Location)
                    .Include(x => x.PhotoUrls)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResidentialComplex> Insert(ResidentialComplex entity)
        {
            try
            {
                await _context.ResidentialComplexes.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResidentialComplex> Update(ResidentialComplex entity)
        {
            try
            {
                _context.ResidentialComplexes.Update(entity);
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
