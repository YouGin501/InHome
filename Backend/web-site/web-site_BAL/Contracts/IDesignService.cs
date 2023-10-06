using Microsoft.AspNetCore.Http;
using web_site_Domain.Models;

namespace web_site_BAL.Contracts
{
    public interface IDesignService
    {
        public Task<IEnumerable<Design>> GetAllDesigns(
            DateTime? startDate,
            DateTime? endDate,
            int? numberOfRecords,
            bool? isOnlyLiked,
            int? userId
        );
        public Task<Design?> GetDesignById(int Id);
        public Task<Design> AddDesign(Design design);
        public Task<Design> UpdateDesign(Design design);
        public Task DeleteDesign(int id);
        public Task AddDesignPhotos(List<IFormFile> files, int designId);
    }
}
