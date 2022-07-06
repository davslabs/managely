using Managely.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Managely.Models.DTO
{
    public class AddTimeOffDto
    {
        [Required]
        public TimeOffReason Reason { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ThruDate { get; set; }
    }
}
