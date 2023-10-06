using Microsoft.AspNetCore.Http;
using web_site_BAL.Contracts;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_BAL.Services
{
    public class RealEstateService : IRealEstateService
    {
        private readonly IRealEstateRepository _realEstateRepository;
        private readonly IImageUrlRepository _imgUrlsRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IAzureBlobStorage _azureBlobService;

        public RealEstateService(
            IRealEstateRepository realEstateRepository,
            IImageUrlRepository imgUrlsRepository,
            IAzureBlobStorage azureBlobService,
            ILocationRepository locationRepository,
            IUserRepository userRepository
        )
        {
            _realEstateRepository = realEstateRepository;
            _imgUrlsRepository = imgUrlsRepository;
            _azureBlobService = azureBlobService;
            _locationRepository = locationRepository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<RealEstate>> GetAllRealEstates(
            DateTime? startDate,
            DateTime? endDate,
            int? numberOfRecords,
            bool? isOnlyNewBuildings,
            bool? isOnlyLiked,
            int? userId
        )
        {
            return await _realEstateRepository.GetAll(
                startDate,
                endDate,
                numberOfRecords,
                isOnlyNewBuildings,
                isOnlyLiked,
                userId
            );
        }

        public async Task<RealEstate?> GetRealEstateById(int Id)
        {
            try
            {
                return await _realEstateRepository.GetById(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RealEstate> AddRealEstate(RealEstate realEstate)
        {
            try
            {
                if (realEstate == null)
                {
                    throw new ArgumentNullException(nameof(realEstate));
                }
                else
                {
                    var location = (
                        await _locationRepository.GetAll(
                            realEstate?.Location?.City,
                            realEstate?.Location?.Country,
                            realEstate?.Location?.Address
                        )
                    ).FirstOrDefault();
                    var user = await _userRepository.GetById(realEstate.UserId);

                    location ??= await _locationRepository.Insert(realEstate.Location);
                    realEstate.User = user;
                    realEstate.Location = location;
                    return await _realEstateRepository.Insert(realEstate);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RealEstate> UpdateRealEstate(RealEstate realEstate)
        {
            try
            {
                RealEstate? realEstateModel = await _realEstateRepository.GetById(realEstate.Id);
                if (realEstate == null)
                {
                    throw new ArgumentNullException(nameof(realEstate));
                }
                else
                {
                    return await _realEstateRepository.Update(realEstate);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteRealEstate(int id)
        {
            try
            {
                RealEstate? realEstate = await GetRealEstateById(id);
                if (realEstate == null)
                {
                    throw new ArgumentNullException(nameof(realEstate));
                }
                else
                {
                    await _realEstateRepository.Delete(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddRealEstatePhotos(List<IFormFile> files, int realEstateId)
        {
            try
            {
                RealEstate? realEstate = await _realEstateRepository.GetById(realEstateId);
                if (realEstate == null)
                {
                    throw new ArgumentNullException(nameof(realEstate));
                }
                else
                {
                    var photos = await _azureBlobService.UploadPhotos(files, "images");
                    if (photos.Count > 0)
                    {
                        if (realEstate.PhotosUrls == null)
                        {
                            realEstate.PhotosUrls = new List<ImageUrl>();
                        }
                        realEstate.PhotosUrls.AddRange(photos);
                    }
                    await _realEstateRepository.Update(realEstate);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
