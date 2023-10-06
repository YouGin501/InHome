using System.Linq.Expressions;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_BAL.Services
{
    public class LikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<IEnumerable<Like>> GetAllLikes(int userId)
        {
            var likes = await _likeRepository.GetAll();
            return likes;
        }

        public async Task<Like?> GetLikeById(int Id)
        {
            return await _likeRepository.GetById(Id);
        }

        public async Task<Like> AddLike(Like like)
        {
            try
            {
                if (like == null)
                {
                    throw new ArgumentNullException(nameof(like));
                }
                else
                {
                    var result = await _likeRepository.Insert(like);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateLike(Like like)
        {
            try
            {
                if (like == null)
                {
                    throw new ArgumentNullException(nameof(like));
                }
                else
                {
                    await _likeRepository.Update(like);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteLike(int id)
        {
            try
            {
                await _likeRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
