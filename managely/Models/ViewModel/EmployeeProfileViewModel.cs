using Managely.Domain.Models;

namespace Managely.Models.ViewModel
{
    public class EmployeeProfileViewModel
    {
        public Guid EmployeeId { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public Guid ReportsToId { get; set; }
        public JobPositionName JobPosition { get; set; }
        public DepartmentName Department { get; set; }
        public RoleName Role { get; set; }
    }
}
