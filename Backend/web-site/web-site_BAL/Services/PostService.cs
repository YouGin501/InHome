using Microsoft.AspNetCore.Http;
using web_site_BAL.Contracts;
using web_site_Domain.Enums;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_BAL.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IImageUrlRepository _imageUrlRepository;
        private readonly IUserRepository _usersRepository;
        private readonly ILocationRepository _locationRepository;

        private readonly IAzureBlobStorage _azureBlobService;

        public PostService(
            IPostRepository postRepository,
            IImageUrlRepository imageUrlRepository,
            IUserRepository userRepository,
            ILocationRepository locationRepository,
            ICommentRepository commentRepository,
            IAzureBlobStorage azureBlobService
        )
        {
            _postRepository = postRepository;
            _imageUrlRepository = imageUrlRepository;
            _usersRepository = userRepository;
            _locationRepository = locationRepository;
            _azureBlobService = azureBlobService;
        }

        public async Task<IEnumerable<Post>> GetAllPosts(int? userId)
        {
            var posts = await _postRepository.GetAll(userId);
            return posts;
        }

        public async Task<IEnumerable<Post>> GetAllPostsForUser(
            int userId,
            string? location,
            UserType? userType
        )
        {
            return await _postRepository.GetPostsForUser(userId, location, userType);
        }

        public async Task<Post?> GetPostById(int Id)
        {
            try
            {
                return await _postRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Post> AddPost(Post post)
        {
            try
            {
                if (post == null)
                {
                    throw new ArgumentNullException(nameof(post));
                }
                else
                {
                    var location = (
                        await _locationRepository.GetAll(
                            post?.Location?.City,
                            post?.Location?.Country,
                            post?.Location?.Address
                        )
                    ).FirstOrDefault();
                    var user = await _usersRepository.GetById(post.UserId);

                    location ??= await _locationRepository.Insert(post.Location);
                    post.User = user;
                    post.Location = location;

                    return await _postRepository.Insert(post);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Post> UpdatePost(int id, Post post)
        {
            try
            {
                Post? postModel = await _postRepository.GetById(id);
                if (post == null)
                {
                    throw new ArgumentNullException(nameof(post));
                }
                else
                {
                    return await _postRepository.Update(post);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeletePost(int id)
        {
            try
            {
                Post? post = await GetPostById(id);
                if (post == null)
                {
                    throw new ArgumentNullException(nameof(post));
                }
                else
                {
                    await _postRepository.Delete(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddPostPhotos(List<IFormFile> files, int postId)
        {
            try
            {
                Post? post = await _postRepository.GetById(postId);
                if (post == null)
                {
                    throw new ArgumentNullException(nameof(post));
                }
                else
                {
                    var photos = await _azureBlobService.UploadPhotos(files, "images");
                    if (photos.Count > 0)
                    {
                        if (post.Photos == null)
                        {
                            post.Photos = new List<ImageUrl>();
                        }
                        post.Photos.AddRange(photos);
                    }
                    await _postRepository.Update(post);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
