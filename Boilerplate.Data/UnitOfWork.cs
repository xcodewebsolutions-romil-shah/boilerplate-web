using Boilerplate.Data.Contracts;
using Boilerplate.Data.Domains;
using Boilerplate.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boilerplate.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BoilerplateDbContext _dbContext;
        private IUserRepository<User> _userRepository;
        private IAccountTransactionRepository<AccountTransaction> _accountTransactionRepository;

        public UnitOfWork(BoilerplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UnitOfWork()
        {
            _dbContext = new BoilerplateDbContext();
        }

        public BoilerplateDbContext Database()
        {
            return _dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IUserRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }

        public IAccountTransactionRepository<AccountTransaction> AccountTransactionRepository
        {
            get
            {
                if (_accountTransactionRepository == null)
                {
                    _accountTransactionRepository = new AccountTransactionRepository(_dbContext);
                }
                return _accountTransactionRepository;
            }
        }


        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
