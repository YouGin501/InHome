using web_site_Domain.Models;

namespace web_site_Domain.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User?> Get(string login, string password);
    }
}
