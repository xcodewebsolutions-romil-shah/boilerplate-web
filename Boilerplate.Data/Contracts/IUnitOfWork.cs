using Boilerplate.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Boilerplate.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        BoilerplateDbContext Database();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        IUserRepository<User> UserRepository { get; }

        IAccountTransactionRepository<AccountTransaction> AccountTransactionRepository { get; }
    }
}
