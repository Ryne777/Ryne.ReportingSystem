using Ryne.ReportingSystem.Application.Models;

namespace Ryne.ReportingSystem.Application.Service.Interfaces
{
    public interface IOrganizationService
    {
        public Task<List<OrganizationDTO>> GetList();
        public Task<OrganizationDetailDTO> GetById(Guid id);
        public Task CreateOne(OrganizationCreateDTO createDTO);
        public Task<bool> UpdateOne(OrganizationCreateDTO updateDTO, Guid id);
        public Task<bool> DeleteOne(Guid id);
    }
}
