using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;

namespace Ryne.ReportingSystem.Application.Service
{
    public class OrganizationService : IOrganizationService
    {
        public Task CreateOne(OrganizationCreateDTO createDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<OrganizationDetailDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrganizationDTO>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOne(OrganizationCreateDTO updateDTO, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
