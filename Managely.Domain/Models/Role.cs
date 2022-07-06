using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managely.Domain.Models
{
    public enum RoleName
    {
        Admin,
        Manager,
        Staff
    }

    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(24)")]
        public RoleName Name { get; set; }
        [Required]
        public bool isEnabled { get; set; }

        public ICollection<Employee> Employee { get; set; }
        public ICollection<RolePermission> RolePermission { get; set; }
    }
}
