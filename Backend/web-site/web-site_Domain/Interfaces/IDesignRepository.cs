using web_site_Domain.Models;

namespace web_site_Domain.Interfaces
{
    public interface IDesignRepository : IRepositoryBase<Design>
    {
        Task<IEnumerable<Design>> GetAll(
            DateTime? startDate,
            DateTime? endDate,
            int? numberOfRecords,
            bool? isOnlyLiked,
            int? userId
        );
    }
}
