using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Trader.Domain.Models;
using Trader.Domain.Services;

namespace Trader.EF.Services
{
    internal class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly DesignTimeDbContext db;

        public GenericDataService(DesignTimeDbContext db)
        {
            this.db = db;
        }
        public async Task<T> Create(T entity)
        {
            using(var dbs = db.CreateDbContext())
            {
               EntityEntry<T> createdEntity = await dbs.Set<T>().AddAsync(entity);
                await dbs.SaveChangesAsync();
                return createdEntity.Entity;  
            }
            
        }

        public async Task<bool> Delete(Guid id)
        {
            using (var dbs = db.CreateDbContext())
            {
                T existingEntity =await dbs.Set<T>().FirstOrDefaultAsync(e=>e.Id==id);
                var createdEntity =  dbs.Set<T>().Remove(existingEntity);
                await dbs.SaveChangesAsync();
                return true;
            }

        }

        public async Task<T> Get(Guid id)
        {
            using (var dbs = db.CreateDbContext())
            {
                T existingEntity = await dbs.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
                return existingEntity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var dbs = db.CreateDbContext())
            {
                List<T> createdEntity = await dbs.Set<T>().ToListAsync();
                return createdEntity;
            }
        }

        public async Task<T> Update(Guid id, T entity)
        {
            using (var dbs = db.CreateDbContext())
            {
                entity.Id = id;
                T existingEntity = await dbs.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

                var createdEntity = dbs.Set<T>().Update(existingEntity);
                await dbs.SaveChangesAsync();
                return entity;
            }
        }
    }
    
}
