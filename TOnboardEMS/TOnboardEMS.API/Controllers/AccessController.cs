using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TOnboardEMS.Repository;

namespace TOnboardEMS.API.Controllers
{
    //Controller responsible for assinging access restrictions.

    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly OnboardContext _Context;
        public AccessController(OnboardContext context) =>  _Context= context;

        //Get 
        [HttpGet()]
        public IActionResult GetAllRoleModuleAccessControl() 
        { 
        
        }

    }
}
