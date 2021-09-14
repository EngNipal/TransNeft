using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TransNeftTest.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly TNEContext dbContext;
        protected readonly DbSet<T> targetDbSet;

        public Type ElementType => typeof(T);
        public Expression Expression { get; }
        public IQueryProvider Provider { get; }
        public IEnumerator<T> GetEnumerator() =>
                             Provider.Execute<IEnumerable<T>>(Expression).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public RepositoryBase(TNEContext context)
        {
            dbContext = context ?? throw new ArgumentNullException(nameof(dbContext));
            targetDbSet = dbContext.Set<T>();
            Expression = Expression.Constant(this);
            Provider = new RepositoryBaseQueryProvider<T>(targetDbSet);
        }

        public RepositoryBase(IQueryProvider provider, Expression expression)
        {
            Provider = provider;
            Expression = expression;
        }

        public async Task AddAsync(T entity)
        {
            await targetDbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var entry =  dbContext.Entry(entity);
            if (entry == null || entry.State == EntityState.Detached)
            {
                targetDbSet.Attach(entity);
            }
            entry.State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await targetDbSet.ToListAsync();
        }
    }
}