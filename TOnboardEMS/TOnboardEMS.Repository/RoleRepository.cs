using TOnboardEMS.Model;
using TOnboardEMS.Repository.Interfaces;

namespace TOnboardEMS.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(OnboardContext context) : base(context)
        {
        }

    }
}