using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TOnboardEMS.Model.DataTypes;

namespace TOnboardEMS.Model
{
    [Table("RoleModuleAccessControl")]
    public class RoleModuleAccessControl
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [ForeignKey("Module")]
        public int ModuleId { get; set; }
        public Restrictions AccessRestriction { get; set;}
    }
}
