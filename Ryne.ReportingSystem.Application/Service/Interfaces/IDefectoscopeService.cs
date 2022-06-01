using Ryne.ReportingSystem.Application.Models;

namespace Ryne.ReportingSystem.Application.Service.Interfaces
{
    public interface IDefectoscopeService
    {
        public Task<List<DefectoscopeDTO>> GetList();
        public Task<DefectoscopeDetailDTO> GetById(Guid id);
        public Task CreateOne(DefectoscopeCreateDTO createDTO);
        public Task<bool> UpdateOne(DefectoscopeCreateDTO updateDTO, Guid id);
        public Task<bool> DeleteOne(Guid id);
    }
}
