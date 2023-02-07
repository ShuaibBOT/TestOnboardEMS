using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TOnboardEMS.Repository.Interfaces
{
    public interface IBaseRepository<T> where T: class
    {
        //Get Alll
        IEnumerable<T> GetAll();
        //Get By ID
        T GetById(int id);
        //Insert
        void Add(T entity);
        //Update
        void Update(T entity);
        //Delete
        void Delete(T entity);
        //Find 
        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate);

    }
}
