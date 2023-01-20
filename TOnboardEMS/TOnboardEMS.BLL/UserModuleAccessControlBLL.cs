using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model;
using TOnboardEMS.Repository;

namespace TOnboardEMS.BLL
{
    public class UserModuleAccessControlBLL
    {
        private readonly OnboardContext Context;
        public UserModuleAccessControlBLL(OnboardContext context)
        {
            Context = context;
        }

        public IEnumerable<UserModuleAccessControl> ViewAllUserModuleAccessControl()
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<UserModuleAccessControlRepository>().GetAll();
            }
        }

        public UserModuleAccessControl ViewUserModuleAccessControlById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<UserModuleAccessControlRepository>().GetById(Id);
            }
        }

        public void AddUserModuleAccessControl(UserModuleAccessControl userModuleAccessControl)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<UserModuleAccessControlRepository>().Add(userModuleAccessControl);
                uow.Commit();

            }
        }

        public void UpdateUserModuleAccessControlDetails(UserModuleAccessControl userModuleAccessControl)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<UserModuleAccessControlRepository>().Update(userModuleAccessControl);
                uow.Commit();
            }
        }

        public void RemoveUserModuleAccessControl(UserModuleAccessControl userModuleAccessControl)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<UserModuleAccessControlRepository>().Delete(userModuleAccessControl);
                uow.Commit();
            }
        }

        public void RemoveRoleById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                UserModuleAccessControlRepository repository = uow.GetRepository<UserModuleAccessControlRepository>();
                repository.Delete(repository.GetById(Id));
                uow.Commit();
            }

        }
    }
}
