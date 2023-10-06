using System.Linq.Expressions;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_BAL.Services
{
    public class LocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await _locationRepository.GetAll();
        }

        public async Task<Location?> GetLocationById(int Id)
        {
            return await _locationRepository.GetById(Id);
        }

        public async Task AddLocation(Location location)
        {
            try
            {
                if (location == null)
                {
                    throw new ArgumentNullException(nameof(location));
                }
                else
                {
                    await _locationRepository.Insert(location);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateLocation(Location location)
        {
            try
            {
                if (location == null)
                {
                    throw new ArgumentNullException(nameof(location));
                }
                else
                {
                    await _locationRepository.Update(location);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteLocation(int id)
        {
            try
            {
                await _locationRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
