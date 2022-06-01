using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;

namespace Ryne.ReportingSystem.Application.Service
{
    public class EngineerService : IEngineerService
    {
        public Task CreateOne(EngineerCreateDTO createDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOne(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<EngineerDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EngineerDTO>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOne(EngineerCreateDTO updateDTO, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
