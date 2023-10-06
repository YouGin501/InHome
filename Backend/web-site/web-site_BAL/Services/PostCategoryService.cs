using System.Linq.Expressions;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_BAL.Services
{
    public class PostCategoryService
    {
        private readonly IPostCategoryRepository _postCategoryRepository;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository)
        {
            _postCategoryRepository = postCategoryRepository;
        }

        public async Task<IEnumerable<PostCategory>> GetAllPostCategories()
        {
            var postCategories = await _postCategoryRepository.GetAll();
            return postCategories;
        }

        public async Task<PostCategory?> GetPostCategoryById(int Id)
        {
            return await _postCategoryRepository.GetById(Id);
        }

        public async Task AddPostCategory(PostCategory postCategory)
        {
            try
            {
                if (postCategory == null)
                {
                    throw new ArgumentNullException(nameof(postCategory));
                }
                else
                {
                    await _postCategoryRepository.Insert(postCategory);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdatePostCategory(PostCategory postCategory)
        {
            try
            {
                if (postCategory == null)
                {
                    throw new ArgumentNullException(nameof(postCategory));
                }
                else
                {
                    await _postCategoryRepository.Update(postCategory);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeletePostCategory(int id)
        {
            try
            {
                await _postCategoryRepository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
