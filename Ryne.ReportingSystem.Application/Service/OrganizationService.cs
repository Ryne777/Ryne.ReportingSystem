using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ryne.ReportingSystem.Application.Models;
using Ryne.ReportingSystem.Application.Service.Interfaces;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application.Service
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public OrganizationService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task CreateOne(OrganizationCreateDTO createDTO)
        {
            var data = _mapper.Map<Organization>(createDTO);
            await _db.Organizations.AddAsync(data);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteOne(Guid id)
        {
            var data = await _db.Organizations.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                _db.Organizations.Remove(data!);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<OrganizationDetailDTO> GetById(Guid id)
        {
            var data = await _db.Organizations.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return null;
            }
            var DTO = _mapper.Map<OrganizationDetailDTO>(data);
            return DTO;
        }

        public async Task<List<OrganizationDTO>> GetList()
        {
            var data = await _db.Organizations.ToArrayAsync();
            var DTO = _mapper.Map<List<OrganizationDTO>>(data);
            return DTO;
        }

        public async Task<bool> UpdateOne(OrganizationCreateDTO updateDTO, Guid id)
        {
            var dataFromDb = await _db.Organizations.FirstOrDefaultAsync(x => x.Id == id);
            if (dataFromDb != null)
            {
                _mapper.Map<OrganizationCreateDTO, Organization>(updateDTO, dataFromDb);
                _db.Organizations.Update(dataFromDb);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
