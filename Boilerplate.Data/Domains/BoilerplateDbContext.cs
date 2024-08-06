using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boilerplate.Data.Domains
{
    public class BoilerplateDbContext : DbContext
    {
        public BoilerplateDbContext()
        {
        }

        public BoilerplateDbContext(DbContextOptions<BoilerplateDbContext> options)
            : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<AccountTransaction> AccountTransactions { get; set; }
        public DbSet<AccountTransactionAudit> AccountTransactionAudits { get; set; }
    }
}
