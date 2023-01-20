using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model;
using TOnboardEMS.Repository;

namespace TOnboardEMS.BLL
{
    public class RoleSubModuleAccessControlBLL
    {
        private readonly OnboardContext Context;
        public RoleSubModuleAccessControlBLL(OnboardContext context)
        {
            Context = context;
        }

        public IEnumerable<RoleSubModuleAccessControl> ViewAllRoleSubModuleAccessControl()
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<RoleSubModuleAccessControlRepository>().GetAll();
            }
        }

        public RoleSubModuleAccessControl ViewRoleSubModuleAccessControlById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<RoleSubModuleAccessControlRepository>().GetById(Id);
            }
        }

        public void AddRoleSubModuleAccessControl(RoleSubModuleAccessControl roleSubModuleAccessControl)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<RoleSubModuleAccessControlRepository>().Add(roleSubModuleAccessControl);
                uow.Commit();

            }
        }

        public void UpdateRoleSubModuleAccessControlDetails(RoleSubModuleAccessControl roleSubModuleAccessControl)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<RoleSubModuleAccessControlRepository>().Update(roleSubModuleAccessControl);
                uow.Commit();
            }
        }

        public void RemoveRoleSubModuleAccessControl(RoleSubModuleAccessControl roleSubModuleAccessControl)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<RoleSubModuleAccessControlRepository>().Delete(roleSubModuleAccessControl);
                uow.Commit();
            }
        }

        public void RemoveRoleSubModuleAccessControlById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                RoleSubModuleAccessControlRepository repository = uow.GetRepository<RoleSubModuleAccessControlRepository>();
                repository.Delete(repository.GetById(Id));
                uow.Commit();
            }

        }
    }
}