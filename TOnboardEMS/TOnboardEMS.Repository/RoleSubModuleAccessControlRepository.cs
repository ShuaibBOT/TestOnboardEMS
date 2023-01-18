using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model;
using TOnboardEMS.Repository.Interfaces;

namespace TOnboardEMS.Repository
{
    public class RoleSubModuleAccessControlRepository : BaseRepository<RoleSubModuleAccessControl> , IRoleSubModuleAccessControlRepository
    {
        public RoleSubModuleAccessControlRepository(OnboardContext context) : base(context) { }
    }
}
