using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOnboardEMS.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly OnboardContext Context;
        public UnitOfWork(OnboardContext context) 
        {
            Context = context;
        }

        public T GetRepository<T>() where T : class 
        {
            T repository = (T)Activator.CreateInstance(typeof(T), Context);
            return repository;
        }
        
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
