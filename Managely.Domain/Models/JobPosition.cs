using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managely.Domain.Models;

public enum JobPositionName
{
    CEO,
    Head,
    Manager,
    Staff,
}

public class JobPosition
{
    [Key]
    public Guid JobPositionId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(24)")]
    public JobPositionName Name { get; set; }
    [Required]
    public string Description { get; set; }
    
    public ICollection<Employee> Employees { get; set; }
}