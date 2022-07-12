using Managely.Domain.Models;

namespace Managely.Models.ViewModel;

public class AddCollaboratorViewModel
{
    public List<EmployeeProfileViewModel> Employees { get; set; }
    public List<DepartmentViewModel> Departments { get; set; }
    public List<RoleViewModel> Roles { get; set; }
    public List<JobPositionViewModel> JobPositions { get; set; }
}

public class JobPositionViewModel
{
    public string Description { get; set; }
    public JobPositionName JobPositionName { get; set; }
}
public class DepartmentViewModel
{
    public string Description { get; set; }
    public DepartmentName DepartmentName { get; set; }
}

public class RoleViewModel
{
    public string Description { get; set; }
    public RoleName RoleName { get; set; }
}