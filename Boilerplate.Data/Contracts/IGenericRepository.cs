using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Data.Contracts
{
    public interface IGenericRepository<TEntity>
       where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Query();

        TEntity Get(Predicate<TEntity> predicate);

        Task CreateAsync(TEntity entity);

        Task CreateRangeAsync(List<TEntity> entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void DeleteRange(List<TEntity> entity);

    }
}
