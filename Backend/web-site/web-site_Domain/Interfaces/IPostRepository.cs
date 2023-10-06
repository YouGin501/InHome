using web_site_Domain.Enums;
using web_site_Domain.Models;

namespace web_site_Domain.Interfaces
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        Task<IEnumerable<Post>> GetPostsForUser(int userId, string? country, UserType? userType);
        Task<IEnumerable<Post>> GetAll(int? userId);
    }
}
