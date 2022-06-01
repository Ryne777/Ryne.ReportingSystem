using Ryne.ReportingSystem.Application.Models;

namespace Ryne.ReportingSystem.Application.Service.Interfaces
{
    public interface IRepairService
    {
        public Task<List<RepairDetailDTO>> GetList();
        public Task<RepairDetailDTO> GetById(Guid id);
        public Task CreateOne(RepairCreateDTO createDTO);
        public Task<bool> UpdateOne(RepairCreateDTO updateDTO, Guid id);
        public Task<bool> DeleteOne(Guid id);

    }
}