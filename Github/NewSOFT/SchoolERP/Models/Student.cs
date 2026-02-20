using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolERP.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Enrollment Number")]
        public string EnrollmentNumber { get; set; } = string.Empty;

        // Added for the Seeder & UI
        public string Grade { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        // Relationship to Classroom (Fixes the Controller/View errors)
        [Display(Name = "Classroom")]
        public int? ClassroomId { get; set; }
        public Classroom? Classroom { get; set; }
    }
}