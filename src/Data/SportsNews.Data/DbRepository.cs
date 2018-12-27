namespace SportsNews.Data
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.EntityFrameworkCore;
    using SportsNews.Web.Models;

    public class DbRepository<TEntity> : IRepository<TEntity>, IDisposable
    where TEntity: class
    {
        private readonly SportsNewsContext context;
        private DbSet<TEntity> dbSet;

        public DbRepository(SportsNewsContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        public Task AddAsync(TEntity entity)
        {
            return this.dbSet.AddAsync(entity);
        }

        public IQueryable<TEntity> All()
        {
            return this.dbSet;
        }

        public void Delete(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public Task<int> SaveChangesAsync()
        {
            return this.context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            this.dbSet.Update(entity);
        }
    }
}
