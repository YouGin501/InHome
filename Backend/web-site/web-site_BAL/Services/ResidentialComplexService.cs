using Microsoft.AspNetCore.Http;
using web_site_BAL.Contracts;
using web_site_Domain.Interfaces;
using web_site_Domain.Models;

namespace web_site_BAL.Services
{
    public class ResidentialComplexService : IResidentialComplexService
    {
        private readonly IResidentialComplexRepository _residentialComplexRepository;
        private readonly IAzureBlobStorage _azureBlobService;
        private readonly IUserRepository _userRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IRealEstateRepository _realEstateRepository;

        public ResidentialComplexService(
            IResidentialComplexRepository residentialComplexRepository,
            IAzureBlobStorage azureBlobService,
            ILocationRepository locationRepository,
            IUserRepository userRepository,
            IRealEstateRepository realEstateRepository
        )
        {
            _residentialComplexRepository = residentialComplexRepository;
            _azureBlobService = azureBlobService;
            _locationRepository = locationRepository;
            _userRepository = userRepository;
            _realEstateRepository = realEstateRepository;
        }

        public async Task<IEnumerable<ResidentialComplex>> GetAllResidentialComplexes(int? userId)
        {
            return await _residentialComplexRepository.GetAll(userId);
        }

        public async Task<IEnumerable<ResidentialComplex>> GetAllResidentialComplexes()
        {
            return await _residentialComplexRepository.GetAll();
        }

        public async Task<ResidentialComplex?> GetResidentialComplexById(int Id)
        {
            try
            {
                return await _residentialComplexRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResidentialComplex> AddResidentialComplex(ResidentialComplex complex)
        {
            try
            {
                if (complex == null)
                {
                    throw new ArgumentNullException(nameof(complex));
                }
                else
                {
                    var user = await _userRepository.GetById(complex.UserId);

                    var location = await _locationRepository.Insert(complex.Location);
                    complex.User = user;

                    complex.LocationId = location.Id;
                    complex.Location = location;
                    var appartments = new List<RealEstate>();
                    if (complex.Apartments != null)
                    {
                        foreach (var a in complex.Apartments)
                        {
                            var appart = await _realEstateRepository.GetById(a.Id);
                            if (appart != null)
                            {
                                appartments.Add(appart);
                            }
                        }
                    }
                    complex.Apartments = appartments;

                    var res = await _residentialComplexRepository.Insert(complex);

                    return res;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ResidentialComplex> UpdateResidentialComplex(ResidentialComplex complex)
        {
            try
            {
                ResidentialComplex? complexModel = await GetResidentialComplexById(complex.Id);
                if (complex == null || complexModel == null)
                {
                    throw new ArgumentNullException(nameof(complex));
                }
                else
                {
                    complexModel.Description = complex.Description;
                    complexModel.Apartments = complex.Apartments;
                    complex.Location = complex.Location;
                    complex.LocationId = complex.LocationId;
                    complex.Name = complex.Name;
                    complex.User = complex.User;
                    complex.UserId = complex.UserId;
                    return await _residentialComplexRepository.Update(complex);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteResidentialComplex(int id)
        {
            try
            {
                ResidentialComplex? complex = await GetResidentialComplexById(id);
                if (complex == null)
                {
                    throw new ArgumentNullException(nameof(complex));
                }
                else
                {
                    await _residentialComplexRepository.Delete(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddResidentialComplexPhotos(
            List<IFormFile> files,
            int residentialComplexId
        )
        {
            try
            {
                ResidentialComplex? residentialComplex =
                    await _residentialComplexRepository.GetById(residentialComplexId);
                if (residentialComplex == null)
                {
                    throw new ArgumentNullException(nameof(residentialComplex));
                }
                else
                {
                    var photos = await _azureBlobService.UploadPhotos(files, "images");
                    if (photos.Count > 0)
                    {
                        if (residentialComplex.PhotoUrls == null)
                        {
                            residentialComplex.PhotoUrls = new List<ImageUrl>();
                        }
                        residentialComplex.PhotoUrls.AddRange(photos);
                    }
                    await _residentialComplexRepository.Update(residentialComplex);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
