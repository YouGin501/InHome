using web_site_Domain.Models;

namespace web_site_Domain.Interfaces
{
    public interface IRealEstateRepository : IRepositoryBase<RealEstate>
    {
        Task<IEnumerable<RealEstate>> GetAll(
            DateTime? startDate,
            DateTime? endDate,
            int? numberOfRecord,
            bool? isOnlyNewBuildings,
            bool? isOnlyLiked,
            int? userId
        );
    }
}
