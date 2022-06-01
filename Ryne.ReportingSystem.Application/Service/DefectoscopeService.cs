using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;

namespace Ryne.ReportingSystem.Application.Service
{
    public class DefectoscopeService : IDefectoscopeService
    {
        public Task CreateOne(DefectoscopeCreateDTO createDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<DefectoscopeDetailDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DefectoscopeDTO>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOne(DefectoscopeCreateDTO updateDTO, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
