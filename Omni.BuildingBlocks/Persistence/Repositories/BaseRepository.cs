﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Omni.BuildingBlocks.Persistence.Repositories.Interfaces;

namespace Omni.BuildingBlocks.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : struct
    {
        private readonly DbContext _dbContext;

        protected BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<TEntity>> GetAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> FindAsync(TKey id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual TEntity Find(TKey id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var entityEntry = await _dbContext.Set<TEntity>().AddAsync(entity);
            return entityEntry.Entity;
        }

        public virtual TEntity Add(TEntity entity)
        {
            var entityEntry = _dbContext.Set<TEntity>().Add(entity);
            return entityEntry.Entity;
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public virtual void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public IIncludableQueryable<TEntity, TProperty> Include<TProperty>(
            Expression<Func<TEntity, TProperty>> navigationPropertyPath) where TProperty : class
        {
            return _dbContext.Set<TEntity>().Include(navigationPropertyPath);
        }
    }
}