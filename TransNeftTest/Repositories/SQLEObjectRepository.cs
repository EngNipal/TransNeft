using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransNeftTest.Models;

namespace TransNeftTest.Repositories
{
    public class SQLEObjectRepository : IRepository<EObject>
    {
        private OrganizationContext _db;
        private const string _messageEObjectAbsent = "Запрошенного потребителя не найдено!";

        public SQLEObjectRepository(OrganizationContext context)
        {
            _db = context;
        }

        public async Task AddAsync(EObject entity)
        {
            await _db.EObjects.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public Task<EObject> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<EObject>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(EObject entity)
        {
            throw new NotImplementedException();
        }
    }
}
