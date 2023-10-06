using web_site_Domain.Models;

namespace web_site_Domain.Interfaces
{
    public interface IFeedbackRepository : IRepositoryBase<Feedback>
    {
        public Task<IEnumerable<Feedback>> GetAll(int? writtenForUserId);
    }
}