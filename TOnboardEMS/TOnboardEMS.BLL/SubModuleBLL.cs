using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model;
using TOnboardEMS.Repository;

namespace TOnboardEMS.BLL
{
    public class SubModuleBLL
    {
        private readonly OnboardContext Context;
        public SubModuleBLL(OnboardContext context)
        {
            Context = context;
        }

        public IEnumerable<SubModule> ViewAllSubModules()
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<SubModuleRepository>().GetAll();
            }
        }

        public SubModule ViewSubModuleById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<SubModuleRepository>().GetById(Id);
            }
        }

        public void AddSubModule(SubModule subModule)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<SubModuleRepository>().Add(subModule);
                uow.Commit();

            }
        }

        public void UpdateSubModuleDetails(SubModule subModule)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<SubModuleRepository>().Update(subModule);
                uow.Commit();
            }
        }

        public void RemoveSubModule(SubModule subModule)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<SubModuleRepository>().Delete(subModule);
                uow.Commit();
            }
        }

        public void RemoveSubModuleById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                SubModuleRepository repository = uow.GetRepository<SubModuleRepository>();
                repository.Delete(repository.GetById(Id));
                uow.Commit();
            }
        }
    }
}
