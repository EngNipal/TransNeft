using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.DTOModels;
using TransNeftTest.Exceptions;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLElectricityMeterRepository : IEMRepository
    {
        private readonly TNEContext _dbContext;
        private IMapper _mapper;
        
        public SQLElectricityMeterRepository(TNEContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task AddAsync(ElectricityMeterDTO dto)
        {
            //var entity = new ElectricityMeter
            //{
            //    Id = dto.Id,
            //    Number = dto.Number,
            //    CheckDate = dto.CheckDate,
            //    Type = dto.Type
            //};

            var entity = _mapper.Map<ElectricityMeterDTO, ElectricityMeter>(dto);

            await _dbContext.ElectricityMeters.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ElectricityMeterDTO> GetAsync(int id)
        {
            var entity = await _dbContext.ElectricityMeters
            .Where(em => em.Id == id)
            .FirstOrDefaultAsync();

            return entity == null
                ? throw new EntityNotFoundException($"Счётчик электроэнергии с Id = {id} не найден.")
                : _mapper.Map<ElectricityMeter, ElectricityMeterDTO>(entity);

                //: new ElectricityMeterDTO
                //{
                //    Id = entity.Id,
                //    Number = entity.Number,
                //    CheckDate = entity.CheckDate,
                //    Type = entity.Type
                //};
        }

        public async Task<IEnumerable<ElectricityMeterDTO>> GetFreeAsync() =>
            await _dbContext.ElectricityMeters.AsNoTracking()
            .Where(em => em.MeterPoint == null)
            .Select(em => new ElectricityMeterDTO
            {
                Id = em.Id,
                Number = em.Number,
                CheckDate = em.CheckDate,
                Type = em.Type
            })
            .ToListAsync();

        public async Task<IEnumerable<ElectricityMeterDTO>> GetExpiredByEObjectAsync(EObjectDTO eObjectDTO) =>
            await _dbContext.ElectricityMeters.AsNoTracking()
            .Where(em => em.MeterPoint.EObjectId == eObjectDTO.Id &&
                        em.CheckDate < DateTime.Now)
            .Select(em => new ElectricityMeterDTO
            {
                Id = em.Id,
                Number = em.Number,
                CheckDate = em.CheckDate,
                Type = em.Type
            })
            .ToListAsync();
    }
}
