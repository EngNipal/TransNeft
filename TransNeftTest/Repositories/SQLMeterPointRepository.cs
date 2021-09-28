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
    public class SQLMeterPointRepository : IRepository<MeterPointDTO>
    {
        private readonly TNEContext _dbContext;
        private IMapper _mapper;

        public SQLMeterPointRepository(TNEContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task AddAsync(MeterPointDTO dto)
        {
            var entity = _mapper.Map<MeterPointDTO, MeterPoint>(dto);

            await _dbContext.MeterPoints.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<MeterPointDTO> GetAsync(int id)
        {
            var entity = await _dbContext.MeterPoints
                .Where(mp => mp.Id == id)
                .FirstOrDefaultAsync();

            return entity == null
                ? throw new EntityNotFoundException($"Точка измерения электроэнергии с Id = {id} не найдена.")
                : _mapper.Map<MeterPoint, MeterPointDTO>(entity);
        }
    }
}