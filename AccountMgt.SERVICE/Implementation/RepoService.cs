using AccountMgt.DATA.Contracts;
using AccountMgt.SERVICE.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountMgt.SERVICE.Implementation
{
    public class RepoService : IRepoService
    {
        private readonly IUnitOfWork uow;
        private IAccountsService _accountsService;
        private IUsersService _usersService;

        public RepoService(IUnitOfWork uow)
        {
            this.uow = uow;
        }


        public IAccountsService AccountsService
        {
            get
            {
                if (_accountsService == null)
                    _accountsService = new AccountsService(uow);

                return _accountsService;
            }
        }

        public IUsersService UsersService
        {
            get
            {
                if (_usersService == null)
                    _usersService = new UsersService(uow);

                return _usersService;
            }
        }
    }
}
