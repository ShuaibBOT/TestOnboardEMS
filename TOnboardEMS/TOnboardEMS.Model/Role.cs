using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TOnboardEMS.Model
{
    [Table("Role")]
    public class Role
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public String? RoleName { get; set; }
        public DateTime? CreatedOn { get; set; }
        [ForeignKey("Employee")]
        public int? CreatedBy { get; set; }
    }
}