using MaybeArchitecture.Core.Entities;
using MaybeArchitecture.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaybeArchitecture.Infrastructure.Data.EF.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext DbContext;
        protected readonly ILogger Logger;
        protected readonly DbSet<T> Table;

        public BaseRepository(AppDbContext managementDbContext, ILogger logger)
        {
            Logger = logger;
            DbContext = managementDbContext;
            Table = DbContext.Set<T>();
        }

        public virtual async Task<bool> AddAsync(T item)
        {
            await Table.AddAsync(item);
            return await SaveChangesAsync();
        }

        public virtual async Task<bool> AddRangeAsync(List<T> items)
        {
            await Table.AddRangeAsync(items);
            return await SaveChangesAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public virtual async Task<bool> UpdateAsync(T item)
        {
            item.ModifiedAt = DateTime.UtcNow;
            Table.Update(item);
            return await SaveChangesAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetListAsync(bool asNoTracking = true)
        {
            return await (asNoTracking ? Table.AsNoTracking().ToListAsync() : Table.ToListAsync());
        }

        public async Task<int> CountAsync()
        {
            return await Table.CountAsync();
        }

        public async Task<bool> IfExitsAsync(int id)
        {
            return await Table.AnyAsync(entity => entity.Id == id);
        }

        protected async Task<bool> SaveChangesAsync()
        {
            try
            {
                int affectedRow = await DbContext.SaveChangesAsync();
                return affectedRow > 0;
            }
            catch (Exception ex)
            {
                Log(ex);
                return false;
            }
        }

        protected void Log(Exception ex)
        {
            Logger.LogError(ex, "{@Exception}", ex);
        }
    }
}
