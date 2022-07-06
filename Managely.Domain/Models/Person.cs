using System;
using System.ComponentModel.DataAnnotations;


namespace Managely.Domain.Models
{
    public abstract class Person
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
