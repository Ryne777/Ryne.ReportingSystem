using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;

namespace Ryne.ReportingSystem.Application.Service
{
    public class TypeOfDefectoscopeService : ITypeOfDefectoscopeService
    {
        public Task CreateOne(TypeOfDefectoscopeCreateDTO createDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TypeOfDefectoscopeDetailDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TypeOfDefectoscopeDTO>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOne(TypeOfDefectoscopeCreateDTO updateDTO, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
