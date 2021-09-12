using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TransNeftTest.Models;
using System.Linq;

namespace TransNeftTest.Repositories
{
    public class SQLCalcMeterRepository : IRepository<CalcMeter>
    {
        private TNEContext _db;
        private const string _messageCalcMeterAbsent = "Запрошенного расчётного прибора учёта не найдено!";

        public SQLCalcMeterRepository(TNEContext context)
        {
            _db = context;
        }

        public async Task AddAsync(CalcMeter entity)
        {
            await _db.CalcMeters.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<CalcMeter> GetAsync(int calcMeterid) => await _db.CalcMeters
            .FirstOrDefaultAsync(cm => cm.Id == calcMeterid);

        public async Task<IQueryable<CalcMeter>> GetListAsync() => (IQueryable<CalcMeter>)await _db.CalcMeters
            .ToListAsync();

        public async Task UpdateAsync(CalcMeter item)
        {
            var calcMeterDb = await _db.CalcMeters.FindAsync(item.Id);
            if (calcMeterDb == null)
            {
                throw new KeyNotFoundException(_messageCalcMeterAbsent);
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
