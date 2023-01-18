using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model;
using TOnboardEMS.Repository;

namespace TOnboardEMS.BLL
{
    public class ModuleBLL
    {
        private readonly OnboardContext Context;
        public ModuleBLL(OnboardContext context)
        {
            Context = context;
        }

        public IEnumerable<Module> ViewAllModules()
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<ModuleRepository>().GetAll();
            }
        }

        public Module ViewModuleById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<ModuleRepository>().GetById(Id);
            }
        }

        public void AddModule(Module module)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<ModuleRepository>().Add(module);
                uow.Commit();
            }
        }

        public void UpdateModuleDetails(Module module)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<ModuleRepository>().Update(module);
                uow.Commit();
            }
        }

        public void RemoveModule(Module module)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<ModuleRepository>().Delete(module);
                uow.Commit();
            }
        }

        public void RemoveModuleById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                RoleRepository repository = uow.GetRepository<RoleRepository>();
                repository.Delete(repository.GetById(Id));
                uow.Commit();
            }
        }
    }
}
