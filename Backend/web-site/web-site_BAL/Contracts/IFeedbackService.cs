using web_site_Domain.Models;

namespace web_site_BAL.Contracts
{
    public interface IFeedbackService
    {
        public Task<IEnumerable<Feedback>> GetAll();
        public Task<IEnumerable<Feedback>> GetAll(int? writtenForUserId);
        public Task<Feedback?> GetById(int id);
        public Task<Feedback> Add(Feedback feedback);
        public Task<Feedback> Update(Feedback feedback);
        public Task Delete(int id);
    }
}
