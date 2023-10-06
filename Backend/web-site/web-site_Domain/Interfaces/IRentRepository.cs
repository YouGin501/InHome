using web_site_Domain.Models;

namespace web_site_Domain.Interfaces
{
    public interface IRentRepository : IRepositoryBase<Rent>
    {
        Task<IEnumerable<Rent>> GetAll(
            DateTime? startDate,
            DateTime? endDate,
            int? numberOfRecords,
            bool? isOnlyLiked,
            int? userId
        );
    }
}
