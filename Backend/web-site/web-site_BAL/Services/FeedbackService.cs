using web_site_BAL.Contracts;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_BAL.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IUserRepository _userRepository;

        public FeedbackService(
            IFeedbackRepository feedbackRepository,
            IUserRepository userRepository
        )
        {
            _feedbackRepository = feedbackRepository;
            _userRepository = userRepository;
        }

        async public Task<Feedback> Add(Feedback feedback)
        {
            try
            {
                if (feedback == null)
                {
                    throw new ArgumentNullException(nameof(feedback));
                }
                else
                {
                    var author = await _userRepository.GetById(feedback.AuthorId);
                    var writtenForUser = await _userRepository.GetById(feedback.WrittenForUserId);

                    feedback.Author = author;
                    feedback.WrittenForUser = writtenForUser;

                    var result = await _feedbackRepository.Insert(feedback);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async public Task Delete(int id)
        {
            try
            {
                await _feedbackRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async public Task<IEnumerable<Feedback>> GetAll()
        {
            try
            {
                return await _feedbackRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        async public Task<IEnumerable<Feedback>> GetAll(int? writtenForUserId)
        {
            try
            {
                return await _feedbackRepository.GetAll(writtenForUserId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async public Task<Feedback?> GetById(int id)
        {
            try
            {
                return await _feedbackRepository.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        async public Task<Feedback> Update(Feedback feedback)
        {
            try
            {
                if (feedback == null)
                {
                    throw new ArgumentNullException(nameof(feedback));
                }
                else
                {
                    var feedbackInDb = await _feedbackRepository.GetById(feedback.Id);
                    if (feedbackInDb != null)
                    {
                        feedbackInDb.Text = feedback.Text;
                        return await _feedbackRepository.Update(feedbackInDb);
                    }
                    else
                    {
                        throw new Exception("Feedback with such id doesn't exist in database.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
