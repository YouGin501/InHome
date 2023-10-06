using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using web_site_BAL.Contracts;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_BAL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ILikeRepository _likeRepository;
        private readonly AzureBlobService _azureBlobService;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IImageUrlRepository _imgUrlRepository;

        public UserService(
            IUserRepository userRepository,
            AzureBlobService azureBlobService,
            ICommentRepository commentRepository,
            ILikeRepository likeRepository,
            IFeedbackRepository reviewRepository,
            ISubscriptionRepository subscriptionRepository,
            IImageUrlRepository imageUrlRepository
        )
        {
            _userRepository = userRepository;
            _azureBlobService = azureBlobService;
            _commentRepository = commentRepository;
            _likeRepository = likeRepository;
            _feedbackRepository = reviewRepository;
            _subscriptionRepository = subscriptionRepository;
            _imgUrlRepository = imageUrlRepository;
        }

        public async Task<User?> LoginUser(string email, string password)
        {
            if (email.IsNullOrEmpty() || password.IsNullOrEmpty())
            {
                throw new ArgumentNullException();
            }
            try
            {
                return await _userRepository.Get(email, password);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return users;
        }

        public async Task<User?> GetUserById(int Id)
        {
            try
            {
                return await _userRepository.GetById(Id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> AddUser(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                else
                {
                    User? checkUserExists = await _userRepository.Get(user.Email, user.Password);
                    if (checkUserExists == null)
                    {
                        return await _userRepository.Insert(user);
                    }
                    else
                    {
                        throw new InvalidDataException("User with this email already registered.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateUser(int id, User user)
        {
            try
            {
                var dbUser = await _userRepository.GetById(id);
                if (dbUser != null)
                {
                    dbUser.Email = user.Email;
                    dbUser.Name = user.Name;
                    dbUser.Information = user.Information;
                    dbUser.Password = user.Password;
                    dbUser.Surname = user.Surname;
                    
                    await _userRepository.Update(dbUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteUser(int userId)
        {
            try
            {
                await _userRepository.Delete(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdatePhoto(IFormFile photo, int userId)
        {
            try
            {
                User? user = await _userRepository.GetById(userId);
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                else
                {
                    if (user.Photo != null && user.Photo.FileName != null)
                    {
                        bool result = await _azureBlobService.DeleteBlob(
                            "images",
                            user.Photo.FileName
                        );
                        if (!result)
                        {
                            throw new Exception($"Failed on deleting img {user.Photo.FileName}");
                        }

                        await _imgUrlRepository.Delete(user.Photo.Id);
                    }
                    var uploadedPhoto = await _azureBlobService.UploadPhoto(photo, "images");
                    uploadedPhoto.User = user;
                    uploadedPhoto.UserId = user.Id;
                    user.Photo = uploadedPhoto;
                    await _userRepository.Update(user);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddDocuments(List<IFormFile> files, int userId)
        {
            try
            {
                User? user = await _userRepository.GetById(userId);
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                else
                {
                    var documents = await _azureBlobService.UploadFiles(files, "documents");
                    if (documents.Count > 0)
                    {
                        if (user.Documents == null)
                        {
                            user.Documents = new List<Document>();
                        }
                        user.Documents.AddRange(documents);
                    }
                    await _userRepository.Update(user);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteDocument(int userId, List<Document> documents)
        {
            try
            {
                User? user = await _userRepository.GetById(userId);
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                else
                {
                    bool isSuccessful = false;
                    foreach (var document in documents)
                    {
                        isSuccessful = await _azureBlobService.DeleteBlob(
                            "documents",
                            document.FileName
                        );
                        if (isSuccessful)
                        {
                            _ = (user?.Documents?.Remove(
                                user?.Documents?.FirstOrDefault(doc => doc.Id == document.Id)
                            ));
                        }
                        else
                        {
                            return isSuccessful;
                        }
                    }

                    await _userRepository.Update(user);

                    return isSuccessful;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
