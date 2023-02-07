using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TOnboardEMS.BLL;
using TOnboardEMS.Model;
using TOnboardEMS.Repository;

namespace TOnboardEMS.API.Controllers
{
    //Controller is responsible for adding/updating/removing module/Sub modules.
    [Route("api/[controller]")]
    [ApiController]
    public class SetModulesController : ControllerBase
    {
        private readonly OnboardContext _Context;
        private SubModuleBLL SubModuleLogic;
        private ModuleBLL ModuleLogic;

        public SetModulesController(OnboardContext context)
        { 
           
            _Context = context;
            SubModuleLogic = new SubModuleBLL(_Context);
            ModuleLogic= new ModuleBLL(_Context);
        }
        //Get
        [HttpGet("GetAllModules")]
        public IActionResult GetAllModules() 
        {
            var response = ModuleLogic.ViewAllModules();
            return Ok(response);
        }

        [HttpGet("GetAllSubModules")]
        public IActionResult GetAllSubModules()
        {
            var response = SubModuleLogic.ViewAllSubModules();
            return Ok(response);
        }
        //GetById
        [HttpGet("GetModuleById")]
        public IActionResult GetModuleById(int id)
        { 
            var response = ModuleLogic.ViewModuleById(id);
            return Ok(response);
        }
        [HttpGet("GetSubModuleById")]
        public IActionResult GetSubModuleById(int id)
        {
            var response = SubModuleLogic.ViewSubModuleById(id);
            return Ok(response);
        }
        //Post
        [HttpPost("AddNewModule")]
        public IActionResult AddNewModule(Module module)
        { 
            ModuleLogic.AddModule(module);
            return Ok("Added New Module.");
        }
        [HttpPost("AddNewSubModule")]
        public IActionResult AddNewSubModule(SubModule subModule)
        {
            SubModuleLogic.AddSubModule(subModule);
            return Ok("Added New SubModule.");
        }
        //Put
        [HttpPut("UpdateModuleDetails")]
        public IActionResult UpdateModuleDetails(Module module)
        { 
           ModuleLogic.UpdateModuleDetails(module);
           return Ok("Module information has been Updated.");
        }
        [HttpPut("UpdateSubModuleDetails")]
        public IActionResult UpdateSubModuleDetails(SubModule subModule)
        { 
            SubModuleLogic.UpdateSubModuleDetails(subModule);
            return Ok("Submodule information has been updated.");
        }
        //Delete
        [HttpDelete("DeleteModuleInformation")]
        public IActionResult DeleteModuleInformation(Module module)
        {
            ModuleLogic.RemoveModule(module);
            return Ok("Module has been removed.");
        }
        [HttpDelete("DeleteSubModuleDetails")]
        public IActionResult DeleteSubModuleDetails(SubModule subModule)
        {
            SubModuleLogic.RemoveSubModule(subModule);
            return Ok("SubModule has been removed.");
        }
    }
}
