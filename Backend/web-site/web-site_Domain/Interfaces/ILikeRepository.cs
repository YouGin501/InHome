using web_site_Domain.Models;

namespace web_site_Domain.Interfaces
{
    public interface ILikeRepository : IRepositoryBase<Like>
    {
        Task<IEnumerable<Like>> GetAll(int? userId);
    }
}
