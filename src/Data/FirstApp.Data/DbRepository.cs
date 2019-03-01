using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstApp.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FirstApp.Data
{
    public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity :class
    {
        private readonly FirstAppContext context;
        private readonly DbSet<TEntity> dbset;

        public DbRepository(FirstAppContext context)
        {
            this.context = context;
            this.dbset = this.context.Set<TEntity>();
        }

        public Task AddAsync(TEntity entity)
        {
            return this.dbset.AddAsync(entity);
        }

        public IQueryable<TEntity> All()
        {
           return this.dbset;
        }

        public void Delete(TEntity entity)
        {
            this.dbset.Remove(entity);
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public Task<int> SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }
    }
}
