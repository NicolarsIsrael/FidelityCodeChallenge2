using AccountMgt.CORE;
using AccountMgt.DATA.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountMgt.DATA.Implementations
{
    public class AccountsRepo : CoreRepo<Accounts>, IAccountsRepo
    {
        private readonly DbSet<Accounts> dbSet;
        private readonly ApplicationDbContext dbContext;
        public AccountsRepo(ApplicationDbContext ctx): base(ctx)
        {
            dbContext = ctx;
            dbSet = dbContext.Set<Accounts>();
        }

        public override Accounts Get(int id)
        {
            return dbContext.Accounts
                .Include(a => a.Users)
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
