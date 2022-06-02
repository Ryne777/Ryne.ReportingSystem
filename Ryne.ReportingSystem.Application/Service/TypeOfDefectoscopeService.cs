using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application.Service
{
    public class TypeOfDefectoscopeService : ITypeOfDefectoscopeService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public TypeOfDefectoscopeService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task CreateOne(TypeOfDefectoscopeCreateDTO createDTO)
        {
            var data = _mapper.Map<TypeOfDefectoscope>(createDTO);
            await _db.TypeOfDefectoscopes.AddAsync(data);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteOne(Guid id)
        {
            var data = await _db.TypeOfDefectoscopes.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                _db.TypeOfDefectoscopes.Remove(data!);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<TypeOfDefectoscopeDetailDTO> GetById(Guid id)
        {
            var data = await _db.TypeOfDefectoscopes.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return null;
            }
            var DTO = _mapper.Map<TypeOfDefectoscopeDetailDTO>(data);
            return DTO;
        }

        public async Task<List<TypeOfDefectoscopeDTO>> GetList()
        {
            var data = await _db.TypeOfDefectoscopes.ToArrayAsync();
            var DTO = _mapper.Map<List<TypeOfDefectoscopeDTO>>(data);
            return DTO;
        }

        public async Task<bool> UpdateOne(TypeOfDefectoscopeCreateDTO updateDTO, Guid id)
        {
            var dataFromDb = await _db.TypeOfDefectoscopes.FirstOrDefaultAsync(x => x.Id == id);
            if (dataFromDb != null)
            {
                _mapper.Map<TypeOfDefectoscopeCreateDTO, TypeOfDefectoscope>(updateDTO, dataFromDb);
                _db.TypeOfDefectoscopes.Update(dataFromDb);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
