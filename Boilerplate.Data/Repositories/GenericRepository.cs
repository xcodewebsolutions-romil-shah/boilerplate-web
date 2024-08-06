using Boilerplate.Data.Contracts;
using Boilerplate.Data.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
       where TEntity : class
    {
        private readonly BoilerplateDbContext _dbContext;

        public GenericRepository(BoilerplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public IQueryable<TEntity> Query()
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public virtual TEntity Get(Predicate<TEntity> predicate)
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(e => predicate(e));
        }


        public virtual async Task CreateAsync(TEntity entity)
        {
            try
            {
                await _dbContext.Set<TEntity>().AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task CreateRangeAsync(List<TEntity> entity)
        {
            try
            {
                await _dbContext.Set<TEntity>().AddRangeAsync(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual void DeleteRange(List<TEntity> entity)
        {
            _dbContext.Set<TEntity>().RemoveRange(entity);
        }

    }
}
