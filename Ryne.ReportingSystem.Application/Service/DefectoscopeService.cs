using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application.Service
{
    public class DefectoscopeService : IDefectoscopeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public DefectoscopeService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<DefectoscopeDTO>> GetList()
        {
            var data = await _db.Defectoscopes.ToArrayAsync();
            var DTO = _mapper.Map<List<DefectoscopeDTO>>(data);
            return DTO;
        }

        public async Task<DefectoscopeDetailDTO> GetById(Guid id)
        {
            var data = await _db.Defectoscopes.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return null;
            }
            var DTO = _mapper.Map<DefectoscopeDetailDTO>(data);
            return DTO;
        }

        public async Task CreateOne(DefectoscopeCreateDTO createDTO)
        {
            var data = _mapper.Map<Defectoscope>(createDTO);
            await _db.Defectoscopes.AddAsync(data);
            await _db.SaveChangesAsync();
        }
        public async Task<bool> UpdateOne(DefectoscopeCreateDTO createDTO, Guid id)
        {
            var dataFromDb = await _db.Defectoscopes.FirstOrDefaultAsync(x => x.Id == id);
            if (dataFromDb != null)
            {
                _mapper.Map<DefectoscopeCreateDTO, Defectoscope>(createDTO, dataFromDb);
                _db.Defectoscopes.Update(dataFromDb);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteOne(Guid id)
        {
            var data = await _db.Defectoscopes.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                _db.Defectoscopes.Remove(data!);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
