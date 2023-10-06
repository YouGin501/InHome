using System.Linq.Expressions;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_BAL.Services
{
    public class SubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<IEnumerable<Subscription>> GetAllSubscriptions()
        {
            var subscriptions = await _subscriptionRepository.GetAll();
            return subscriptions;
        }

        public async Task<Subscription?> GetSubscriptionById(int Id)
        {
            try
            {
                return await _subscriptionRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddSubscription(Subscription subscription)
        {
            try
            {
                if (subscription == null)
                {
                    throw new ArgumentNullException(nameof(subscription));
                }
                else
                {
                    await _subscriptionRepository.Insert(subscription);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateSubscription(Subscription subscription)
        {
            try
            {
                if (subscription == null)
                {
                    throw new ArgumentNullException(nameof(subscription));
                }
                else
                {
                    await _subscriptionRepository.Update(subscription);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteSubscription(int id)
        {
            try
            {
                await _subscriptionRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
