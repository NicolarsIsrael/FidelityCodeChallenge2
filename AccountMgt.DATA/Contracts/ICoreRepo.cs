using AccountMgt.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountMgt.DATA.Contracts
{
    public interface ICoreRepo<T> where T : Entity
    {
        IQueryable<T> Get();

        T Get(object id);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
