using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLElectricityMeterRepository : IRepository<ElectricityMeter>
    {
        private TNEContext _db;
        private const string _messageElectricityMeterAbsent = "Запрошенного счётчика электроэнергии не найдено!";

        public SQLElectricityMeterRepository(TNEContext context)
        {
            _db = context;
        }

        public async Task AddAsync(ElectricityMeter entity)
        {
            await _db.ElectricityMeters.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<ElectricityMeter> GetAsync(int id) => await _db.ElectricityMeters
            .Include(em => em.MeterPoint)
            .FirstOrDefaultAsync(em => em.Id == id);

        public async Task<IQueryable<ElectricityMeter>> GetListAsync() => (IQueryable<ElectricityMeter>)await _db.ElectricityMeters
            .Include(em => em.MeterPoint)
            .ToListAsync();

        public async Task UpdateAsync(ElectricityMeter item)
        {
            var electricityMeterDb = await _db.ElectricityMeters.FindAsync(item.Id);
            if (electricityMeterDb == null)
            {
                throw new KeyNotFoundException(_messageElectricityMeterAbsent);
            }

            electricityMeterDb.Number = item.Number;
            electricityMeterDb.CheckDate = item.CheckDate;
            electricityMeterDb.MeterPointId = item.MeterPointId;
            electricityMeterDb.MeterPoint = item.MeterPoint;
            electricityMeterDb.Type = item.Type;

            await _db.SaveChangesAsync();
        }
    }
}
