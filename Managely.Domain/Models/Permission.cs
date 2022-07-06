using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managely.Domain.Models
{
    public enum PermissionName
    {
        Create,
        Read,
        Update,
        Delete
    }

    public class Permission
    {
        [Key]
        public Guid PermissionId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(24)")]
        public PermissionName Name { get; set; }

        public ICollection<RolePermission> RolePermission { get; set; }
    }
}
