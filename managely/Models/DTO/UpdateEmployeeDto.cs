using System.ComponentModel.DataAnnotations;

namespace Managely.Models.DTO;

public class UpdateEmployeeDto
{
    public string? Phone { get; set; }
    public string? Location { get; set; }
    public Guid? ReportsTo { get; set; }
}