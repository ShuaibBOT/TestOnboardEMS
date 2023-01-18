using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model;

namespace TOnboardEMS.Repository
{
    public class OnboardContext : DbContext
    {
        public OnboardContext(DbContextOptions<OnboardContext> options) : base(options) { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<SubModule> SubModule { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleModuleAccessControl> RoleModuleAccessControl { get; set;}
        public DbSet<RoleSubModuleAccessControl> RoleSubModuleAccessControl { get; set; }
        public DbSet<UserModuleAccessControl> UserModuleAccessControl { get; set; }
        public DbSet<UserSubModuleAccessControl> UserSubModuleAccessControl { get; set; }

    }
}
