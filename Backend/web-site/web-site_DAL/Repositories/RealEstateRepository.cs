using Microsoft.EntityFrameworkCore;
using web_site_DAL.Data;
using web_site_Domain.Enums;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_DAL.Repositories
{
    public class RealEstateRepository : IRealEstateRepository
    {
        private readonly WebSiteDbContext _context;

        public RealEstateRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int entityId)
        {
            try
            {
                var entity = await _context.RealEstates.FirstOrDefaultAsync(x => x.Id == entityId);
                if (entity != null)
                {
                    _context.RealEstates.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async public Task<IEnumerable<RealEstate>> GetAll(
            DateTime? startDate,
            DateTime? endDate,
            int? numberOfRecord,
            bool? isOnlyNewBuildings,
            bool? isOnlyLiked,
            int? userId
        )
        {
            try
            {
                var realEstates = _context.RealEstates.AsQueryable();
                if (startDate != null)
                {
                    realEstates = realEstates.Where(x => x.CreationDate <= (DateTime)startDate);
                }
                if (endDate != null)
                {
                    realEstates = realEstates.Where(x => x.CreationDate >= (DateTime)endDate);
                }
                if (isOnlyNewBuildings != null)
                {
                    if (isOnlyNewBuildings == true)
                        realEstates = realEstates.Where(
                            x => x.RealEstateStatus == RealEstateStatus.NewBuilding
                        );
                    else
                        realEstates = realEstates.Where(
                            x => x.RealEstateStatus != RealEstateStatus.NewBuilding
                        );
                }
                if (isOnlyLiked != null)
                {
                    realEstates = realEstates.Where(x => x.Likes != null);
                }
                if (numberOfRecord != null)
                {
                    realEstates = realEstates.Take((int)numberOfRecord);
                }
                if (userId != null)
                {
                    realEstates = realEstates.Where(x => x.UserId == userId);
                }

                return await realEstates
                    .Include(x => x.User)
                    .Include(x => x.PhotosUrls)
                    .Include(x => x.Likes)
                    .Include(x => x.ResidentialComplex)
                    .Include(x => x.Location)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RealEstate>> GetAll()
        {
            try
            {
                return await _context.RealEstates
                    .Include(x => x.User)
                    .Include(x => x.PhotosUrls)
                    .Include(x => x.Likes)
                    .Include(x => x.ResidentialComplex)
                    .Include(x => x.Location)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        async public Task<RealEstate?> GetById(int id)
        {
            return await _context.RealEstates
                .Include(x => x.User)
                .Include(x => x.Likes)
                .Include(x => x.ResidentialComplex)
                .Include(x => x.PhotosUrls)
                .Include(x => x.Location)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<RealEstate> Insert(RealEstate entity)
        {
            try
            {
                await _context.RealEstates.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RealEstate> Update(RealEstate entity)
        {
            try
            {
                _context.RealEstates.Update(entity);
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
