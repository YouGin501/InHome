using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_site_Domain.Models;

namespace web_site_Domain.Interfaces
{
    public interface IResidentialComplexRepository : IRepositoryBase<ResidentialComplex>
    {
        public Task<IEnumerable<ResidentialComplex>> GetAll(int? userId);
    }
}
