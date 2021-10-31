using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LearningPlatformWebAPI.Database.Models;

namespace LearningPlatformWebAPI.Database
{
    public class Repository<T> : IRepository<T> where T : ModelBase
    {
        private readonly AppContext _appContext;

        public Repository(AppContext appContext)
        {
            _appContext = appContext;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _appContext.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _appContext.Set<T>().ToList();
        }

        public T GetByGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _appContext.Set<T>().RemoveRange(entities);
        }

        public void Add(T entity)
        {
            _appContext.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _appContext.Set<T>().Remove(entity);
        }
    }
}