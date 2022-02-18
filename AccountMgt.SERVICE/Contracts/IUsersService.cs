using AccountMgt.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMgt.SERVICE.Contracts
{
    public interface IUsersService
    {
        Users Get(int accountId, int userId);
        IQueryable<Users> Get(int accountId);
        Task Add(Users user);
        Task Update(Users user);
        Task Delete(Users user);
    }
}
