using AccountMgt.CORE;
using AccountMgt.DATA.Contracts;
using AccountMgt.DATA.Implementations;
using AccountMgt.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMgt.SERVICE.Implementation
{
    public class AccountsService : IAccountsService
    {
        private readonly UnitOfWork _uow;
        public AccountsService(IUnitOfWork uow)
        {
            _uow = uow as UnitOfWork;
        }

        public async Task Add(Accounts account)
        {
            _uow.AccountsRepo.Add(account);
            await _uow.Save();
        }

        public async Task Delete(Accounts account)
        {
            _uow.AccountsRepo.Delete(account);
            await _uow.Save();
        }

        public IQueryable<Accounts> Get()
        {
            return _uow.AccountsRepo.Get();
        }

        public Accounts Get(int id)
        {
            return _uow.AccountsRepo.Get(id);
        }

        public async Task Update(Accounts account)
        {
            _uow.AccountsRepo.Update(account);
            await _uow.Save();
        }
    }
}
