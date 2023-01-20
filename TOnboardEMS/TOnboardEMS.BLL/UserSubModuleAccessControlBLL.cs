using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model;
using TOnboardEMS.Repository;

namespace TOnboardEMS.BLL
{
    public class UserSubModuleAccessControlBLL
    {
        private readonly OnboardContext Context;
        public UserSubModuleAccessControlBLL(OnboardContext context)
        {
            Context = context;
        }

        public IEnumerable<UserSubModuleAccessControl> ViewAllUserSubModuelAccessControls()
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<UserSubModuelAccessControlRepository>().GetAll();
            }
        }

        public UserSubModuleAccessControl ViewUserSubModuelAccessControlById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<UserSubModuelAccessControlRepository>().GetById(Id);
            }
        }

        public void AddUserSubModuelAccessControl(UserSubModuleAccessControl userSubModuleAccessControlBLL)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<UserSubModuelAccessControlRepository>().Add(userSubModuleAccessControlBLL);
                uow.Commit();

            }
        }

        public void UpdateUserSubModuelAccessControleDetails(UserSubModuleAccessControl userSubModuleAccessControlBLL)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<UserSubModuelAccessControlRepository>().Update(userSubModuleAccessControlBLL);
                uow.Commit();
            }
        }

        public void RemoveUserSubModuelAccessControl(UserSubModuleAccessControl userSubModuleAccessControlBLL)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<UserSubModuelAccessControlRepository>().Delete(userSubModuleAccessControlBLL);
                uow.Commit();
            }
        }

        public void RemoveUserSubModuelAccessControlById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                UserSubModuelAccessControlRepository repository = uow.GetRepository<UserSubModuelAccessControlRepository>();
                repository.Delete(repository.GetById(Id));
                uow.Commit();
            }
        }
    }
}
