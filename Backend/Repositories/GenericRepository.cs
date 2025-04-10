using Backend.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly AgendaContext _context;
        private readonly DbSet<TEntity> _dbSet;


        public GenericRepository(AgendaContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
        {
            var entityListFromDatabase = _dbSet.Where(predicate).ToListAsync();
            if (entityListFromDatabase == null)
            {
                throw new KeyNotFoundException("Registry not found in database.");
            }

            return await entityListFromDatabase;
        }


        public async Task<TEntity?> GetByIdAsync(int id)
        {
            var entityFromDatabase = await _dbSet.FindAsync(id);
            if (entityFromDatabase == null)
            {
                throw new KeyNotFoundException($"Registry with ID = {id} was not found in database.");
            }

            return entityFromDatabase;
        }


        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entireDatabase = await _dbSet.ToListAsync();
            if (entireDatabase == null)
            {
                throw new KeyNotFoundException($"Database is empty.");
            }

            return entireDatabase;
        }


        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return addedEntity.Entity;
        }


        public async Task UpdateAsync(int id, TEntity entity)
        {
            var registryInDatabase = await GetByIdAsync(id);

            if (registryInDatabase == null)
            {
                throw new KeyNotFoundException($"Registry with ID = {id} was not found in database.");
            }

            _context.Entry(registryInDatabase).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }


        internal async Task DeleteAsync(int id)
        {
            var registryInDatabase = await GetByIdAsync(id);
            if (registryInDatabase == null)
            {
                throw new KeyNotFoundException($"Registry with ID = {id} was not found in database.");
            }

            _context.Remove(registryInDatabase);
            await _context.SaveChangesAsync();
        }
    }
}
