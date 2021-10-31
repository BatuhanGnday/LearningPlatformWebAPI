using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LearningPlatformWebAPI.Database.Models;

namespace LearningPlatformWebAPI.Database
{
    public interface IRepository<T> where T : ModelBase
    {
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        T GetByGuid(Guid guid);
        void RemoveRange(IEnumerable<T> entities);
        void Add(T entity);

        void Remove(T entity);
        // void Update(T entity);
    }
}