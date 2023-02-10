using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOnboardEMS.Model
{
    [Table("SubModule")]
    public class SubModule
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Module")]
        public int ModuleId { get; set; }
        public String SubModuleDescription { get; set; }
    }
}
