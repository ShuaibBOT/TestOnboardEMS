using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
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
                Debug.WriteLine("Shuaib: userModuleAccessPool: " + userModuleAccessPool.ModuleId);
                IEnumerable<SubModule> listofSubModules = subModuleRepository.Query(e => e.ModuleId == moduleId);
                
                List<int> listofSubModulesId= new List<int>();
                foreach (var subModule in listofSubModules)
                {
                    Debug.WriteLine("Shuaib: listofSubModulesId: " + subModule.Id);
                    Debug.WriteLine("Shuaib: ModuleIdSub " + subModule.ModuleId);
                    if (subModule.ModuleId == moduleId)
                    {
                        listofSubModulesId.Add(subModule.Id);
                    }
                }
                IEnumerable<RoleSubModuleAccessControl> listOfSubModuleAccessControl = roleSubModuleAccessControlRepository.Query(e => e.RoleId == roleId && listofSubModulesId.Contains(e.SubModuleId));
                List<ResponseSubModule> listofResponseSubModuleDetails = new List<ResponseSubModule>();
                foreach (var subModules in listOfSubModuleAccessControl)
                {
                    Debug.WriteLine("Shuaib: subModule " + subModules.Id);
                    ResponseSubModule responseSubModule = new ResponseSubModule();
                    responseSubModule.SubModuleID = subModules.Id;
                    responseSubModule.AccessRestrictions = subModules.AccessRestriction;
                    Debug.WriteLine("Shuaib: responseSubModule :" + responseSubModule.SubModuleID);
                    Debug.WriteLine("Shuaib: responseSubModule " + responseSubModule.AccessRestrictions);
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

        public String UpdateSubModulesByModulePerRole(ResponseRoleSubModulePerModule requestBody, int roleId)
        {
            using (var uow = new UnitOfWork(Context))
            {
                // 1. Check if Parental Id is existing
                var roleModuleAccessControlRepository =uow.GetRepository<RoleModuleAccessControlRepository>();
                var moduleValue = roleModuleAccessControlRepository.QueryFirstOrDefault(x=> x.RoleId == roleId && x.ModuleId ==requestBody.parentID);
                if (moduleValue == null)
                {
                    //Print Value does not exist (Module ) (return value)
                    return ("Module Id is not found");
                }

                // 3. Take count of all Sub Modules belonging to that specific Module.
                var subModuleRepository=uow.GetRepository<SubModuleRepository>();
                var expectedSubModuleList = subModuleRepository.Query(x => x.ModuleId == requestBody.parentID);
                int expectedSubModuleCount = expectedSubModuleList.Count();
                // 4. Check if the actual sub module count is the same as the expected count
                if (requestBody.ListOfSubModules.Count != expectedSubModuleCount)
                {
                    //Print Actual Count not the same as expected count (return Value)
                    return ("Sub Module Count for this module is not the same as what is expected.");
                }

                // 5. Check if all submodule exist and belong to that module.
                bool isSame = false;
                isSame = expectedSubModuleList.Any(x => requestBody.ListOfSubModules.Any(y => y.SubModuleID == x.Id));
                if (isSame == false) 
                {
                    //Print Value no the same (return value)
                    return ("SubModule ID passed does not belong to the given Module ID");
                }

                try
                {
                    //  Update Parental Access restrictions.

                    moduleValue.AccessRestriction = requestBody.parentRestrictions;
                    roleModuleAccessControlRepository.Update(moduleValue);


                    //  Update Sub Module Access restrictions.
                    var roleSubModuleAccessControlRepository=uow.GetRepository<RoleSubModuleAccessControlRepository>();
                    var subModuleList = roleSubModuleAccessControlRepository.Query(x => x.RoleId == roleId && expectedSubModuleList.Any(y => y.Id == x.SubModuleId));
                    for(var i=0; i< expectedSubModuleCount; i++ )
                    {
                        subModuleList.ElementAt(i).AccessRestriction = requestBody.ListOfSubModules[i].AccessRestrictions;
                        roleSubModuleAccessControlRepository.Update(subModuleList.ElementAt(i));
                    }
                    uow.Commit();

                }
                catch(Exception ex) 
                {
                    // Print error (return value);
                    return ("Error when updating to database "+ex);
                }

                return ("Update Succesfully done");
            }


        }
    }
}
