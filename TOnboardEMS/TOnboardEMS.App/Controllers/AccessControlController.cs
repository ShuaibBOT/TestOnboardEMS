using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TOnboardEMS.BLL;
using TOnboardEMS.Model;
using TOnboardEMS.Repository;

namespace TOnboardEMS.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessControlController : ControllerBase
    {
        private readonly OnboardContext Context;

        public AccessControlController(OnboardContext context)
        {
            Context = context;
        }

        [HttpGet("GetAllRoles")]
        public ActionResult GetAllRoles()
        {
            RoleBLL RoleLogic = new RoleBLL(Context);
            var results=RoleLogic.ViewAllRoles();
            if (results == null)
            {
                return NotFound();
            }
            else
            {
                Console.WriteLine(results);
                return Ok(results);
            }
        }

        [HttpPost("AddNewRole")]
        public ActionResult AddNewRole(Role roleData)
        {
            RoleBLL RoleLogic = new RoleBLL(Context);
            if (roleData == null)
            {
                return BadRequest("Bad Request");
            }
            else
            {
                RoleLogic.AddRole(roleData);
                return Ok("New Role is Added.");
            }
        }

        [HttpDelete("DeleteRole")]
        public ActionResult DeleteRole(Role roleData)
        {
            RoleBLL RoleLogic = new RoleBLL(Context);
            if (roleData == null)
            {
                return BadRequest("Bad Request");
            }
            else 
            {
                return Ok("Successfully Deleted");
            }
        }

    }
}
