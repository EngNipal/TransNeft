using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using TransNeftTest.Exceptions;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLMeterPointRepository : IRepository<MeterPoint>
    {
        private readonly TNEContext _dbContext;

        public SQLMeterPointRepository(TNEContext context)
        {
            _dbContext = context;
        }

        public async Task AddAsync(MeterPoint entity)
        {
            var electricityMeter = await _dbContext.ElectricityMeters
                .FirstOrDefaultAsync(em => em.Id == entity.ElectricityMeterId);

            var currentTransformer = await _dbContext.CurrentTransformers
                .FirstOrDefaultAsync(ct => ct.Id == entity.CurrentTransformerId);

            var voltageTransformer = await _dbContext.VoltageTransformers
                .FirstOrDefaultAsync(vt => vt.Id == entity.VoltageTransformerId);
            
            var eObject = await _dbContext.EObjects
                .FirstOrDefaultAsync(eo => eo.Id == entity.EObjectId);

            var calcMeter = await _dbContext.CalcMeters
                .FirstOrDefaultAsync(cm => cm.Id == entity.CalcMeterId);

            if (electricityMeter == null ||
                currentTransformer == null ||
                voltageTransformer == null ||
                eObject == null ||
                calcMeter == null)
            {
                throw new ArgumentException($"{nameof(entity)} is not valid");
            }

            entity.ElectricityMeter = electricityMeter;
            entity.CurrentTransformer = currentTransformer;
            entity.VoltageTransformer = voltageTransformer;
            entity.EObject = eObject;
            entity.CalcMeter = calcMeter;

            await _dbContext.MeterPoints.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            electricityMeter.MeterPointId = entity.Id;
            electricityMeter.MeterPoint = entity;
            currentTransformer.MeterPointId = entity.Id;
            currentTransformer.MeterPoint = entity;
            voltageTransformer.MeterPointId = entity.Id;
            voltageTransformer.MeterPoint = entity;
            eObject.MeterPoints.Add(entity);
            calcMeter.MeterPointId = entity.Id;
            calcMeter.MeterPoint = entity;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id) =>
            await _dbContext.MeterPoints.AnyAsync(x => x.Id == id);

        public async Task<MeterPoint> GetAsync(int id)
        {
            var entity = await _dbContext.MeterPoints
                .AsNoTracking()
                .FirstOrDefaultAsync(mp => mp.Id == id);

            return entity ?? throw new EntityNotFoundException($"Точка измерения электроэнергии с Id = {id} не найдена.");
        }
    }
}