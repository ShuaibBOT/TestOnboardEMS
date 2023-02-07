using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Repository.Interfaces;

namespace TOnboardEMS.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly OnboardContext Context;

        public BaseRepository(OnboardContext context)
        {
            Context = context;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);   
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate) 
        { 
             var results= Context.Set<T>().Where(predicate).ToList();
            return results;
        }
    }
}
