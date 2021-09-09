using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLCalcMeterRepository : IRepository<CalcMeter>
    {
        private OrganizationContext _db;
        private const string _messageCalcMeterAbsent = "Запрошенного расчётного прибора учёта не найдено!";

        public SQLCalcMeterRepository(OrganizationContext context)
        {
            _db = context;
        }

        public async Task AddAsync(CalcMeter entity)
        {
            await _db.CalcMeters.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<CalcMeter> GetAsync(int calcMeterid) => await _db.CalcMeters
            .Include(cm => cm.DeliveryPoint)
            .Include(cm => cm.MeterPoint)
            .FirstOrDefaultAsync(cm => cm.Id == calcMeterid);

        public async Task<IList<CalcMeter>> GetListAsync() => await _db.CalcMeters
            .Include(cm => cm.DeliveryPoint)
            .Include(cm => cm.MeterPoint)
            .ToListAsync();

        public async Task SaveAsync() => await _db.SaveChangesAsync();

        public async Task UpdateAsync(CalcMeter item)
        {
            var calcMeterDb = await _db.CalcMeters.FindAsync(item.Id);
            if (calcMeterDb == null)
            {
                throw new Exception(_messageCalcMeterAbsent);
            }

            calcMeterDb.Number = item.Number;
            calcMeterDb.StartDate = item.StartDate;
            calcMeterDb.EndDate = item.EndDate;
            calcMeterDb.DeliveryPointId = item.DeliveryPointId;
            calcMeterDb.DeliveryPoint = item.DeliveryPoint;
            calcMeterDb.MeterPointId = item.MeterPointId;
            calcMeterDb.MeterPoint = item.MeterPoint;

            await _db.SaveChangesAsync();
        }
    }
}
