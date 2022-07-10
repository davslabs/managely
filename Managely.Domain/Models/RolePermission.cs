using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managely.Domain.Models
{
    public class RolePermission
    {
        [Key]
        public Guid RolePermissionId { get; set; }
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        [ForeignKey("Permission")]
        public Guid PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
