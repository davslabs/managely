using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managely.Domain.Models;

public enum DepartmentName
{
    Board,
    IT,
    Finance,
    Sales,
    Marketing,
    CustomerService,
    HumanResources,
}

public class Department
{
    [Key]
    public Guid DepartmentId { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(24)")]
    public DepartmentName Name { get; set; }
    public string Description { get; set; }
    
    public ICollection<Employee> Employees { get; set; }
}