using Microsoft.AspNetCore.Http;
using web_site_Domain.Models;

namespace web_site_BAL.Contracts
{
    public interface IRealEstateService
    {
        public Task<IEnumerable<RealEstate>> GetAllRealEstates(
            DateTime? startDate,
            DateTime? endDate,
            int? numberOfRecords,
            bool? isOnlyNewBuildings,
            bool? isOnlyLiked,
            int? userId
        );

        public Task<RealEstate?> GetRealEstateById(int Id);
        public Task<RealEstate> AddRealEstate(RealEstate realEstate);
        public Task<RealEstate> UpdateRealEstate(RealEstate realEstate);
        public Task DeleteRealEstate(int id);
        public Task AddRealEstatePhotos(List<IFormFile> files, int realEstateId);
    }
}
