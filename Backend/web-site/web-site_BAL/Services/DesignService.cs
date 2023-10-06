using Microsoft.AspNetCore.Http;
using web_site_BAL.Contracts;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_BAL.Services
{
    public class DesignService : IDesignService
    {
        private readonly IDesignRepository _designRepository;
        private readonly IImageUrlRepository _imgUrlsRepository;
        private readonly IAzureBlobStorage _azureBlobService;
        private readonly IUserRepository _userRepository;

        public DesignService(
            IDesignRepository designRepository,
            IImageUrlRepository imageUrlRepository,
            IUserRepository userRepository,
            IAzureBlobStorage azureBlobService
        )
        {
            _designRepository = designRepository;
            _imgUrlsRepository = imageUrlRepository;
            _userRepository = userRepository;
            _azureBlobService = azureBlobService;
        }

        public async Task<IEnumerable<Design>> GetAllDesigns(
            DateTime? startDate,
            DateTime? endDate,
            int? numberOfRecords,
            bool? isOnlyLiked,
            int? userId
        )
        {
            return await _designRepository.GetAll(startDate, endDate, numberOfRecords, isOnlyLiked, userId);
        }

        public async Task<Design?> GetDesignById(int Id)
        {
            try
            {
                return await _designRepository.GetById(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Design> AddDesign(Design design)
        {
            try
            {
                if (design == null)
                {
                    throw new ArgumentNullException(nameof(design));
                }
                else
                {
                    var user = await _userRepository.GetById(design.UserId);
                    design.User = user;
                    return await _designRepository.Insert(design);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Design> UpdateDesign(Design design)
        {
            try
            {
                Design? designModel = await _designRepository.GetById(design.Id);
                if (design == null)
                {
                    throw new ArgumentNullException(nameof(design));
                }
                else
                {
                    return await _designRepository.Update(design);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteDesign(int id)
        {
            try
            {
                Design? design = await GetDesignById(id);
                if (design == null)
                {
                    throw new ArgumentNullException(nameof(design));
                }
                else
                {
                    await _designRepository.Delete(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddDesignPhotos(List<IFormFile> files, int designId)
        {
            try
            {
                Design? design = await _designRepository.GetById(designId);
                if (design == null)
                {
                    throw new ArgumentNullException(nameof(design));
                }
                else
                {
                    var photos = await _azureBlobService.UploadPhotos(files, "images");
                    if (photos.Count > 0)
                    {
                        if (design.PhotosUrls == null)
                        {
                            design.PhotosUrls = new List<ImageUrl>();
                        }
                        design.PhotosUrls.AddRange(photos);
                    }
                    await _designRepository.Update(design);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
