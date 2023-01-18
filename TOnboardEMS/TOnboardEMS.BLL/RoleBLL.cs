using Microsoft.EntityFrameworkCore;
using TOnboardEMS.Model;
using TOnboardEMS.Repository;

namespace TOnboardEMS.BLL
{
    public class RoleBLL
    {
        private readonly OnboardContext Context;
        public RoleBLL(OnboardContext context) 
        {
            Context = context;
        }

        public IEnumerable<Role> ViewAllRoles() 
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<RoleRepository>().GetAll();
            }
        }

        public Role ViewRoleById(int Id)
        {
            using (var uow = new UnitOfWork(Context))
            {
                return uow.GetRepository<RoleRepository>().GetById(Id);
            }
        }

        public void AddRole(Role role)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<RoleRepository>().Add(role);
                uow.Commit();

            }
        }

        public void UpdateRoleDetails(Role role)
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<RoleRepository>().Update(role);
                uow.Commit();
            }
        }

        public void RemoveRole(Role role) 
        {
            using (var uow = new UnitOfWork(Context))
            {
                uow.GetRepository<RoleRepository>().Delete(role);
                uow.Commit();
            }
        }

        public void RemoveRoleById(int Id)
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