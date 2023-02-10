using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model;
using TOnboardEMS.Model.Response;
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

        // Get All SubModules for a Modules per Role
        public ResponseRoleSubModulePerModule GetSubModulesByModulePerRole(int roleId, int moduleId)
        {
            using (var uow = new UnitOfWork(Context)) 
            { 
                RoleSubModuleAccessControlRepository roleSubModuleAccessControlRepository = uow.GetRepository<RoleSubModuleAccessControlRepository>();
                RoleModuleAccessControlRepository roleModuleAccessControlRepository = uow.GetRepository<RoleModuleAccessControlRepository>();
                SubModuleRepository subModuleRepository = uow.GetRepository<SubModuleRepository>();

                RoleModuleAccessControl userModuleAccessPool = roleModuleAccessControlRepository.QueryFirstOrDefault(e => e.RoleId == roleId && e.ModuleId == moduleId);
                IEnumerable<SubModule> listofSubModules = subModuleRepository.Query(e => e.ModuleId == moduleId);
                List<int> listofSubModulesId= new List<int>();
                foreach (var subModule in listofSubModules)
                {
                    if (subModule.ModuleId == moduleId)
                    {
                        listofSubModulesId.Add(subModule.Id);
                    }
                }
                IEnumerable<RoleSubModuleAccessControl> listOfSubModuleAccessControl = roleSubModuleAccessControlRepository.Query(e => e.RoleId == roleId && listofSubModulesId.Contains(e.SubModuleId));
                List<ResponseSubModule> listofResponseSubModuleDetails = new List<ResponseSubModule>();
                foreach (var subModules in listOfSubModuleAccessControl)
                {
                    ResponseSubModule responseSubModule = new ResponseSubModule();
                    responseSubModule.SubModuleID = subModules.Id;
                    responseSubModule.AccessRestrictions = subModules.AccessRestriction;
                    listofResponseSubModuleDetails.Add(responseSubModule);
                }
                ResponseRoleSubModulePerModule response = new ResponseRoleSubModulePerModule(
                    userModuleAccessPool.Id,
                    userModuleAccessPool.AccessRestriction,
                    listofResponseSubModuleDetails
                    );
                return response;
            }
        }
    }
}
