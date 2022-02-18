using AccountMgt.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMgt.SERVICE.Contracts
{
    public interface IAccountsService
    {
        IQueryable<Accounts> Get();
        Accounts Get(int id);
        Task Add(Accounts account);
        Task Update(Accounts account);
        Task Delete(Accounts account);
    }
}
