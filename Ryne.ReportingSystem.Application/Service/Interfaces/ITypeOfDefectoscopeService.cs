using Ryne.ReportingSystem.Application.Models;

namespace Ryne.ReportingSystem.Application.Service.Interfaces
{
    public interface ITypeOfDefectoscopeService
    {
        public Task<List<TypeOfDefectoscopeDTO>> GetList();
        public Task<TypeOfDefectoscopeDetailDTO> GetById(Guid id);
        public Task CreateOne(TypeOfDefectoscopeCreateDTO createDTO);
        public Task<bool> UpdateOne(TypeOfDefectoscopeCreateDTO updateDTO, Guid id);
        public Task<bool> DeleteOne(Guid id);
    }
}
