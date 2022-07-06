using Managely.Domain.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Managely.Models.DTO
{
    public class AddEmployeeDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public JobPositionName JobPosition { get; set; }
        [Required]
        public DepartmentName Department { get; set; }
        [Required]
        public RoleName Role { get; set; }

        public Guid? ReportsTo { get; set; }
    }
}
