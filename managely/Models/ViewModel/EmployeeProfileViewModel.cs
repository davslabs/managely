using Managely.Domain.Models;

namespace Managely.Models.ViewModel
{
    public class EmployeeProfileViewModel
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string ReportsTo { get; set; }
        public string JobPosition { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        
    }
}
