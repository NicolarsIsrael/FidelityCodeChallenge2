using System;
using System.Collections.Generic;
using System.Text;

namespace AccountMgt.SERVICE.Contracts
{
    public interface IRepoService
    {
        IAccountsService AccountsService { get; }
    }
}
