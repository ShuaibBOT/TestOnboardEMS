using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model;
using TOnboardEMS.Repository.Interfaces;

namespace TOnboardEMS.Repository
{
    public class RoleModuleAccessControlRepository : BaseRepository<RoleModuleAccessControl>, IRoleModuleAccessControlRepository
    {
        public RoleModuleAccessControlRepository(OnboardContext context) : base(context) { }
    }
}
