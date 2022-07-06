using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Managely.Domain.Models
{
    public enum TimeOffReason
    {
        Vacation,
        Holiday,
        StudyDay,
        Sickness
    }

    public class TimeOff
    {
        [Key]
        public Guid TimeOffId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(24)")]
        public TimeOffReason Reason { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ThruDate { get; set; }

        public ICollection<EmployeeTimeOff> EmployeeTimeOffs { get; set; }
    }
}
