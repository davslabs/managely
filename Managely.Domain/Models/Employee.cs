using Managely.Domain.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managely.Domain.Models
{
    public class Employee : Person, IDisplayable
    {
        public Employee()
        {
            IsActive = true;
            EmployeeTimeOffs = new HashSet<EmployeeTimeOff>();
            StartDate = DateTime.Now;
        }

        [Key]
        public Guid EmployeeId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        
        public string AvatarUrl { get; set; }
        
        [Required]
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        
        [ForeignKey("JobPosition")]
        public Guid JobPositionId { get; set; }
        public virtual JobPosition JobPosition { get; set; }
        
        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }


        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }


        [ForeignKey("Employee")]
        public Guid? ReportsToId { get; set; }
        public Employee ReportsTo { get; set; }

        public ICollection<EmployeeTimeOff>? EmployeeTimeOffs { get; set; }

        [NotMapped]
        public string DisplayName => LastName + ", " + Name;
    }
}
