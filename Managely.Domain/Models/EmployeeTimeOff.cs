using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managely.Domain.Models
{
    public class EmployeeTimeOff
    {
        [Key]
        public Guid EmployeTimeOffId { get; set; }
        [ForeignKey("Employee")]
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [ForeignKey("TimeOff")]
        public Guid TimeOffId { get; set; }
        public TimeOff TimeOff { get; set; }
    }
}
