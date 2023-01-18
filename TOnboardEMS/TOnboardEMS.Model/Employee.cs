using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOnboardEMS.Model
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("Employee")]
        public int SupervisorId { get; set; }
        public String FirstName { get; set; }
        public String lastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        [NotMapped]
        public DateOnly DateJoined { get; set; }
        public int PeriodOfEmployment { get; set; }
        public String WorkEmailAddress { get; set; }
        [NotMapped]
        public String ActivityStatus { get; set; }
        [NotMapped]
        public String Status { get; set; }
        [ForeignKey("Projects")]
        [NotMapped]
        public int PrimaryProject { get; set; }
        [ForeignKey("Projects")]
        [NotMapped]
        public int SecondaryProjects { get; set; }
        [NotMapped]
        public DateTime CreatedOn { get; set; }
        [ForeignKey("Employee")]
        [NotMapped]
        public int CreatedBy { get; set;}
    }
}
