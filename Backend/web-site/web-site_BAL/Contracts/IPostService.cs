using Microsoft.AspNetCore.Http;
using web_site_Domain.Enums;
using web_site_Domain.Models;

namespace web_site_BAL.Contracts
{
    public interface IPostService
    {
        public Task<IEnumerable<Post>> GetAllPosts(int? userId);
        public Task<IEnumerable<Post>> GetAllPostsForUser(
            int userId,
            string? location,
            UserType? userType
        );
        public Task<Post?> GetPostById(int Id);
        public Task<Post> AddPost(Post post);
        public Task<Post> UpdatePost(int id, Post post);
        public Task DeletePost(int id);
        public Task AddPostPhotos(List<IFormFile> files, int postId);
    }
}