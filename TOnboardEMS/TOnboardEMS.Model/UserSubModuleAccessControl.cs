using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOnboardEMS.Model
{
    [Table("UserSubModuleAccessControl")]
    public class UserSubModuleAccessControl
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("SubModule")]
        public int SubModuleId { get; set; }
        public String AccessRestriction { get; set; }

    }
}
