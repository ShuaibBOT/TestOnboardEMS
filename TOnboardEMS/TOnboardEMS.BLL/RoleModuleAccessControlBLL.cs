using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model;
using TOnboardEMS.Repository;

namespace TOnboardEMS.BLL
{
    public class RoleModuleAccessControlBLL
    {
        private readonly OnboardContext Context;
        public RoleModuleAccessControlBLL(OnboardContext context)
        {
            Context = context;
        }

        public IEnumerable<RoleModuleAccessControl> ViewAllRoleModuleAccessControl()
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<RoleModuleAccessControlRepository>().GetAll();
            }
        }

        public RoleModuleAccessControl ViewRoleModulAccessControleById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<RoleModuleAccessControlRepository>().GetById(Id);
            }
        }

        public void AddRoleModuleAccessControl(RoleModuleAccessControl roleModuleAccessControl)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<RoleModuleAccessControlRepository>().Add(roleModuleAccessControl);
                uow.Commit();
            }
        }

        public void UpdateRoleModuleAccessControlDetails(RoleModuleAccessControl roleModuleAccessControl)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<RoleModuleAccessControlRepository>().Update(roleModuleAccessControl);
                uow.Commit();
            }
        }

        public void RemoveRoleModuleAccessControl(RoleModuleAccessControl roleModuleAccessControl)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<RoleModuleAccessControlRepository>().Delete(roleModuleAccessControl);
                uow.Commit();
            }
        }

        public void RemoveRoleModuleAccessControlById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                RoleModuleAccessControlRepository repository = uow.GetRepository<RoleModuleAccessControlRepository>();
                repository.Delete(repository.GetById(Id));
                uow.Commit();
            }
        }
    }
}
