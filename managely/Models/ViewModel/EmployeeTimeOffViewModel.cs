using Managely.Domain.Models;

namespace Managely.Models.ViewModel;

public class EmployeeTimeOffViewModel
{
    public TimeOffReason Reason { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ThruDate { get; set; }
}