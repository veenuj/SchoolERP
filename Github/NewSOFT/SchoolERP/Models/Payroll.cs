using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolERP.Models
{
    public class Payroll
    {
        public int Id { get; set; }

        [Required]
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        [Required]
        public string Month { get; set; } = string.Empty; // e.g., "October"
        
        [Required]
        public int Year { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal BaseSalary { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Allowances { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Deductions { get; set; }

        public decimal NetSalary => (BaseSalary + Allowances) - Deductions;

        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        public bool IsPaid { get; set; }
    }
}