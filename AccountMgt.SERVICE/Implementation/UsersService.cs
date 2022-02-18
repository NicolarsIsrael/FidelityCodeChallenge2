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
    public class UsersService : IUsersService
    {
        UnitOfWork _uow;
        public UsersService(IUnitOfWork uow)
        {
            _uow = uow as UnitOfWork;
        }
        public async Task Add(Users user)
        {
            _uow.UsersRepo.Add(user);
            await _uow.Save();
        }

        public async Task Delete(Users user)
        {
            _uow.UsersRepo.Delete(user);
            await _uow.Save();
        }

        public IQueryable<Users> Get(int accountId)
        {
            return _uow.UsersRepo.Find(u => u.AccountId == accountId);
        }

        public Users Get(int accountId, int userId)
        {
            return _uow.UsersRepo.Find(u => u.AccountId == accountId && u.Id == userId).FirstOrDefault();
        }

        public async Task Update(Users user)
        {
            _uow.UsersRepo.Update(user);
            await _uow.Save();
        }

    }
}
