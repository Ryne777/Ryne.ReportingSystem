using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application.Service
{
    public class RepairService : IRepairService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public RepairService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }


        public async Task<List<RepairDetailDTO>> GetList()
        {
            var data = await _db.Repairs.ToArrayAsync();
            var DTO = _mapper.Map<List<RepairDetailDTO>>(data);
            return DTO;
        }

        public async Task<RepairDetailDTO> GetById(Guid id)
        {
            var data = await _db.Repairs.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return null;
            }
            var DTO = _mapper.Map<RepairDetailDTO>(data);
            return DTO;
        }

        public async Task CreateOne(RepairCreateDTO createDTO)
        {
            var data = _mapper.Map<Repair>(createDTO);
            await _db.Repairs.AddAsync(data);
            await _db.SaveChangesAsync();
        }
        public async Task<bool> UpdateOne(RepairCreateDTO createDTO, Guid id)
        {
            var dataFromDb = await _db.Repairs.FirstOrDefaultAsync(x => x.Id == id);
            if (dataFromDb != null)
            {
                _mapper.Map<RepairCreateDTO, Repair>(createDTO, dataFromDb);
                _db.Repairs.Update(dataFromDb);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteOne(Guid id)
        {
            var data = await _db.Repairs.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                _db.Repairs.Remove(data!);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
