using Boilerplate.Data.Contracts;
using Boilerplate.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Data.Repositories
{
    public class AccountTransactionRepository : GenericRepository<AccountTransaction>, IAccountTransactionRepository<AccountTransaction>
    {
        private readonly BoilerplateDbContext _dbContext;

        public AccountTransactionRepository(BoilerplateDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
