// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Data.Entity;
using Taygeta.Repositories;
using JetBrains.Annotations;

namespace Taygeta.DataAccessLayer
{
    public class DataRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<TEntity> _dbSet;

        public DataRepository([NotNull] DataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = dataContext.Set<TEntity>();
        }

        /// <inheritdoc />
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> Get<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath, Func<TEntity, bool> predicate = null)
        {
            return _dbSet.Include(navigationPropertyPath).Where(predicate ?? (e => true));
        }

        /// <inheritdoc />
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate = null)
        {           
            return _dbSet.Where(predicate ?? (e => true));            
        }

        /// <inheritdoc />
        public void Remove(TEntity entity)
        {
            if (_dataContext.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        /// <inheritdoc />
        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity).State = EntityState.Modified;
        }
    }
}
