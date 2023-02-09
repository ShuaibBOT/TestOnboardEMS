using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TOnboardEMS.BLL;
using TOnboardEMS.Model;
using TOnboardEMS.Repository;

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
            var response=_roleModuleAccessControlBLL.ViewAllRoleModuleAccessControl();
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
        [HttpPut]
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
        [HttpPut]
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
        [HttpPut]
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
        //DELETE

    }
}
