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
    public class CoreRepo<TEntity> : ICoreRepo<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Entity> _DbSet;

        public CoreRepo(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._DbSet = this._dbContext.Set<Entity>();
        }

        public void Add(TEntity entity)
        {
            if (entity is Entity)
                (entity as Entity).DateCreated = DateTime.Now;

            _dbContext.Set<TEntity>().Add(entity);
        }

        public TEntity Get(object id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAllWithDelete()
        {
            return _dbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
