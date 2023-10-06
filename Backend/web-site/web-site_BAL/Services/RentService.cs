using Microsoft.AspNetCore.Http;
using web_site_BAL.Contracts;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_BAL.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly IImageUrlRepository _imgUrlsRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IAzureBlobStorage _azureBlobService;

        public RentService(
            IRentRepository rentRepository,
            IImageUrlRepository imageUrlRepository,
            ILocationRepository locationRepository,
            IUserRepository userRepository,
            IAzureBlobStorage azureBlobService
        )
        {
            _rentRepository = rentRepository;
            _imgUrlsRepository = imageUrlRepository;
            _locationRepository = locationRepository;
            _userRepository = userRepository;
            _azureBlobService = azureBlobService;

        }

        public async Task<IEnumerable<Rent>> GetAllRents(
            DateTime? startDate,
            DateTime? endDate,
            int? numberOfRecords,
            bool? isOnlyLiked,
            int? userId
        )
        {
            return await _rentRepository.GetAll(startDate, endDate, numberOfRecords, isOnlyLiked, userId);
        }

        public async Task<Rent?> GetRentById(int Id)
        {
            try
            {
                return await _rentRepository.GetById(Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Rent> AddRent(Rent rent)
        {
            try
            {
                if (rent == null)
                {
                    throw new ArgumentNullException(nameof(rent));
                }
                else
                {
                    var location = (
                        await _locationRepository.GetAll(
                            rent?.Location?.City,
                            rent?.Location?.Country,
                            rent?.Location?.Address
                        )
                    ).FirstOrDefault();
                    var user = await _userRepository.GetById(rent.UserId);

                    location ??= await _locationRepository.Insert(rent.Location);
                    rent.User = user;
                    rent.Location = location;

                    return await _rentRepository.Insert(rent);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Rent> UpdateRent(Rent rent)
        {
            try
            {
                Rent? rentModel = await _rentRepository.GetById(rent.Id);
                if (rent == null)
                {
                    throw new ArgumentNullException(nameof(rent));
                }
                else
                {
                    return await _rentRepository.Update(rent);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteRent(int id)
        {
            try
            {
                Rent? rent = await GetRentById(id);
                if (rent == null)
                {
                    throw new ArgumentNullException(nameof(rent));
                }
                else
                {
                    await _rentRepository.Delete(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddRentPhotos(List<IFormFile> files, int rentId)
        {
            try
            {
                Rent? rent = await _rentRepository.GetById(rentId);
                if (rent == null)
                {
                    throw new ArgumentNullException(nameof(rent));
                }
                else
                {
                    var photos = await _azureBlobService.UploadPhotos(files, "images");
                    if (photos.Count > 0)
                    {
                        if (rent.PhotosUrls == null)
                        {
                            rent.PhotosUrls = new List<ImageUrl>();
                        }
                        rent.PhotosUrls.AddRange(photos);
                    }
                    await _rentRepository.Update(rent);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
