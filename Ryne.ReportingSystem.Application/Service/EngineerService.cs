using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application.Service
{
    public class EngineerService : IEngineerService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public EngineerService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task CreateOne(EngineerCreateDTO createDTO)
        {
            var data = _mapper.Map<Engineer>(createDTO);
            await _db.Engineers.AddAsync(data);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteOne(Guid id)
        {
            var data = await _db.Engineers.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                _db.Engineers.Remove(data!);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<EngineerDTO> GetById(Guid id)
        {
            var data = await _db.Engineers.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return null;
            }
            var DTO = _mapper.Map<EngineerDTO>(data);
            return DTO;
        }

        public async Task<List<EngineerDTO>> GetList()
        {
            var data = await _db.Engineers.ToArrayAsync();
            var DTO = _mapper.Map<List<EngineerDTO>>(data);
            return DTO;
        }

        public async Task<bool> UpdateOne(EngineerCreateDTO updateDTO, Guid id)
        {
            var dataFromDb = await _db.Engineers.FirstOrDefaultAsync(x => x.Id == id);
            if (dataFromDb != null)
            {
                _mapper.Map<EngineerCreateDTO, Engineer>(updateDTO, dataFromDb);
                _db.Engineers.Update(dataFromDb);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
