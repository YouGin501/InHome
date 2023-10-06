using web_site_Domain.Models;

namespace web_site_Domain.Interfaces
{
    public interface ILocationRepository : IRepositoryBase<Location>
    {
        Task<IEnumerable<Location>> GetAll(string? city, string? country, string? address);
    }
}
