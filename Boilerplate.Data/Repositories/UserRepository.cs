using Boilerplate.Data.Contracts;
using Boilerplate.Data.Domains;

namespace Boilerplate.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository<User>
    {
        private readonly BoilerplateDbContext _dbContext;

        public UserRepository(BoilerplateDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
