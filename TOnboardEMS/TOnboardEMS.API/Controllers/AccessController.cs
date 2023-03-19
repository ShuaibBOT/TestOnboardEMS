using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text;
using TOnboardEMS.BLL;
using TOnboardEMS.Model;
using TOnboardEMS.Model.Request;
using TOnboardEMS.Model.Response;
using TOnboardEMS.Repository;
using Nancy.Json;

namespace TOnboardEMS.API.Controllers
{
    //Controller responsible for assinging access restrictions.

    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {

        private RoleModuleAccessControlBLL _roleModuleAccessControlBLL;
        private RoleSubModuleAccessControlBLL _roleSubModuleAccessControlBLL;
        private UserModuleAccessControlBLL _userModuleAccessControlBLL;
        private UserSubModuleAccessControlBLL _userSubModuleAccessControlBLL;
        public AccessController(OnboardContext context) {
            _roleModuleAccessControlBLL = new RoleModuleAccessControlBLL(context);
            _roleSubModuleAccessControlBLL = new RoleSubModuleAccessControlBLL(context);
            _userModuleAccessControlBLL = new UserModuleAccessControlBLL(context);
            _userSubModuleAccessControlBLL = new UserSubModuleAccessControlBLL(context);
        }

        //Get 
        [HttpGet("GetAllRoleModuleAccessControl")]
        public IActionResult GetAllRoleModuleAccessControl()
        {
            var response = _roleModuleAccessControlBLL.ViewAllRoleModuleAccessControl();
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }
        [HttpGet("GetAllRoleSubModuleAccessControl")]
        public IActionResult GetAllRoleSubModuleAccessControl()
        {
            var response = _roleSubModuleAccessControlBLL.ViewAllRoleSubModuleAccessControl();
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }
        [HttpGet("GetAllUserModuleAccessControl")]
        public IActionResult GetAllUserModuleAccessControl()
        {
            var response = _userModuleAccessControlBLL.ViewAllUserModuleAccessControl();
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }
        [HttpGet("GetAllUserSubModuleAccessControl")]
        public IActionResult GetAllUserSubModuleAccessControl()
        {
            var response = _userSubModuleAccessControlBLL.ViewAllUserSubModuelAccessControl();
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }

        //Post
        [HttpPost("AddRoleModuleAccessControl")]
        public IActionResult AddRoleModuleAccessControl(RoleModuleAccessControl response)
        {
            if (response != null)
            {
                _roleModuleAccessControlBLL.AddRoleModuleAccessControl(response);
                return Ok("Successfully added RoleModuleAccessControl");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("AddRoleSubModuleAccessControl")]
        public IActionResult AddRoleSubModuleAccessControl(RoleSubModuleAccessControl response)
        {
            if (response != null)
            {
                _roleSubModuleAccessControlBLL.AddRoleSubModuleAccessControl(response);
                return Ok("Successfully added RoleSubModuleAccessControl");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("AddUserModuleAccessControl")]
        public IActionResult AddUserModuleAccessControl(UserModuleAccessControl response)
        {
            if (response != null)
            {
                _userModuleAccessControlBLL.AddUserModuleAccessControl(response);
                return Ok("Successfully added UserModuleAccessControl");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost("AddUserSubModuleAccessControl")]
        public IActionResult AddUserSubModuleAccessControl(UserSubModuleAccessControl response)
        {
            if (response != null)
            {
                _userSubModuleAccessControlBLL.AddUserSubModuelAccessControl(response);
                return Ok("Successfully added UserSubModuleAccessControl");
            }
            else
            {
                return BadRequest();
            }
        }
        //PUT
        [HttpPut("UpdateRoleModuleAccessControl")]
        public IActionResult UpdateRoleModuleAccessControl(RoleModuleAccessControl response)
        {
            if (response != null)
            {
                _roleModuleAccessControlBLL.UpdateRoleModuleAccessControlDetails(response);
                return Ok("Successfully Updated RoleModuleAccessControl");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateRoleSubModuleAccessControl")]
        public IActionResult UpdateRoleSubModuleAccessControl(RoleSubModuleAccessControl response)
        {
            if (response != null)
            {
                _roleSubModuleAccessControlBLL.UpdateRoleSubModuleAccessControlDetails(response);
                return Ok("Successfully Updated RoleSubModuleAccessControl");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateUserSubModuleAccessControl")]
        public IActionResult UpdateUserSubModuleAccessControl(UserSubModuleAccessControl response)
        {
            if (response != null)
            {
                _userSubModuleAccessControlBLL.UpdateUserSubModuelAccessControleDetails(response);
                return Ok("Successfully Updated UserSubModuleAccessControl");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateUserModuleAccessControl")]
        public IActionResult UpdateUserModuleAccessControl(UserModuleAccessControl response)
        {
            if (response != null)
            {
                _userModuleAccessControlBLL.UpdateUserModuleAccessControlDetails(response);
                return Ok("Successfully Updated UserModuleAccessControl");
            }
            else
            {
                return BadRequest();
            }
        }
        //DELETE
        [HttpDelete("DeleteRoleModuleAccessControl")]
        public IActionResult DeleteRoleModuleAccessControl(RoleModuleAccessControl response)
        {
            if (response != null)
            {
                _roleModuleAccessControlBLL.RemoveRoleModuleAccessControl(response);
                return Ok("Successfully Removed RoleModuleAccessControl from system");
            }
            else {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteRoleSubModuleAccessControl")]
        public IActionResult DeleteRoleSubModuleAccessControl(RoleSubModuleAccessControl response)
        {
            if (response != null)
            {
                _roleSubModuleAccessControlBLL.RemoveRoleSubModuleAccessControl(response);
                return Ok("Successfully Removed RoleSubModuleAccessControl from system");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteUserModuleAccessControl")]
        public IActionResult DeleteUserModuleAccessControl(UserModuleAccessControl response)
        {
            if (response != null)
            {
                _userModuleAccessControlBLL.RemoveUserModuleAccessControl(response);
                return Ok("Successfully Removed UserModuleAccessControl from system");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteUserSubModuleAccessControl")]
        public IActionResult DeleteUserSubModuleAccessControl(UserSubModuleAccessControl response)
        {
            if (response != null)
            {
                _userSubModuleAccessControlBLL.RemoveUserSubModuelAccessControl(response);
                return Ok("Successfully Removed UserSubModuleAccessControl from system");
            }
            else
            {
                return BadRequest();
            }
        }

        //Get All SubModules per Module per User

        [HttpGet("GetAllSubModulesPerModuleAndRole")]
        public IActionResult GetAllSubModulesPerModuleAndRole(int roleId, int ModuleId)
        {
            Debug.WriteLine("Shuaib: RoleId - " + roleId + " ModuleId - " + ModuleId);
            var response = _roleModuleAccessControlBLL.GetSubModulesByModulePerRole(roleId,ModuleId);
            if (response != null) 
            {
                var json = new JavaScriptSerializer().Serialize(response);
                return Ok(json); 
            }
            else 
            {  
                return BadRequest();
            }
        }

        //Patch Update all Sub-module as per Module per User.
        [HttpPatch()]
        public IActionResult UpdateSubModuleAccessRestrictionsPerModule(int roleId, ResponseRoleSubModulePerModule requestBody)
        {
            if (requestBody != null)
            {
                var responseMessage = _roleModuleAccessControlBLL.UpdateSubModulesByModulePerRole(requestBody, roleId);
                return Ok(responseMessage);
            }
            else 
            { 
               return BadRequest("Bad Request");
            }
        }

        


    }
}
