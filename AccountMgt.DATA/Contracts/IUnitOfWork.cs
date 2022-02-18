using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountMgt.DATA.Contracts
{
    public interface IUnitOfWork
    {
        Task Save();
    }
}
