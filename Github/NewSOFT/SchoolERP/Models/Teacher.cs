using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolERP.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; } = DateTime.Now;
    }
}