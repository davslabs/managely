using Managely.Domain.Models;

namespace Managely.Models.ViewModel;

public class EmployeeRelationsViewModel
{
    public Guid EmployeeId { get; set; }
    public string DisplayName { get; set; }
    public string JobPosition { get; set; }
    public string Department { get; set; }
    public string Email { get; set; }
    public Guid? ReportTo { get; set; }
}