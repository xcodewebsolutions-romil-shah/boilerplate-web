using Boilerplate.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Data.Contracts
{
    public interface IAccountTransactionRepository<TEntity> : IGenericRepository<TEntity>
       where TEntity : AccountTransaction
    {
    }
}
