using Ryne.ReportingSystem.Application.Models;

namespace Ryne.ReportingSystem.Application.Service.Interfaces
{
    public interface IEngineerService
    {
        public Task<List<EngineerDTO>> GetList();
        public Task<EngineerDTO> GetById(Guid id);
        public Task CreateOne(EngineerCreateDTO createDTO);
        public Task<bool> UpdateOne(EngineerCreateDTO updateDTO, Guid id);
        public Task<bool> DeleteOne(Guid id);
    }
}
