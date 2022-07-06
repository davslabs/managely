using Managely.Domain.Models;

namespace Managely.Models.ViewModel;

public class EmployeeDepartmentViewModel
{
    public EmployeeDepartmentViewModel()
    {
        Employees = new List<EmployeeProfileViewModel>();
    }
    
    public DepartmentName Department { get; set; }
    
    public ICollection<EmployeeProfileViewModel> Employees { get; set; }
}