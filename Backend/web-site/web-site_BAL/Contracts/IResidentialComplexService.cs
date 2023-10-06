using Microsoft.AspNetCore.Http;
using web_site_Domain.Models;

namespace web_site_BAL.Contracts
{
    public interface IResidentialComplexService
    {
        public Task<IEnumerable<ResidentialComplex>> GetAllResidentialComplexes();
        public Task<IEnumerable<ResidentialComplex>> GetAllResidentialComplexes(int? userId);
        public Task<ResidentialComplex?> GetResidentialComplexById(int Id);
        public Task<ResidentialComplex> AddResidentialComplex(ResidentialComplex complex);
        public Task<ResidentialComplex> UpdateResidentialComplex(ResidentialComplex complex);
        public Task DeleteResidentialComplex(int id);
        public Task AddResidentialComplexPhotos(List<IFormFile> files, int residentialComplexId);
    }
}
