using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model;
using TOnboardEMS.Repository.Interfaces;

namespace TOnboardEMS.Repository
{
    public class UserModuleAccessControlRepository : BaseRepository<UserModuleAccessControl>, IUserModuleAccessControlRepository
    {
        public UserModuleAccessControlRepository(OnboardContext context) : base(context) { }
    }
}
