using AccountMgt.CORE;
using AccountMgt.DATA.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountMgt.DATA.Implementations
{
    public class UsersRepo : CoreRepo<Users>, IUsersRepo
    {
        private DbSet<Users> dbSet;
        private ApplicationDbContext dbContext;
        public UsersRepo(ApplicationDbContext ctx):base(ctx)
        {
            dbContext = ctx;
            dbSet = dbContext.Set<Users>();
        }
    }
}
