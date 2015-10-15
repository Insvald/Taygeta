// The Taygeta Project
// (c) 2015 Ilya Rovensky

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace Taygeta.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get<TProperty>([NotNull] Expression<Func<TEntity, TProperty>> navigationPropertyPath, Func<TEntity, bool> predicate = null);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate = null);
        void Add([NotNull] TEntity entity);
        void Update([NotNull] TEntity entity);
        void Remove([NotNull] TEntity entity);
    }
}
