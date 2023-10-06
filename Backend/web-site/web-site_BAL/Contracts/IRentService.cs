using Microsoft.AspNetCore.Http;
using web_site_Domain.Models;

namespace web_site_BAL.Contracts
{
    public interface IRentService
    {
        public Task<IEnumerable<Rent>> GetAllRents(
            DateTime? startDate,
            DateTime? endDate,
            int? numberOfRecords,
            bool? isOnlyLiked,
            int? userId
        );
        public Task<Rent?> GetRentById(int Id);
        public Task<Rent> AddRent(Rent rent);
        public Task<Rent> UpdateRent(Rent rent);
        public Task DeleteRent(int id);
        public Task AddRentPhotos(List<IFormFile> files, int rentId);
    }
}