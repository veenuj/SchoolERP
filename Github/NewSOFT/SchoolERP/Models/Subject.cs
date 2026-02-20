using System.ComponentModel.DataAnnotations;

namespace SchoolERP.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty; // e.g., MATH101
        public int Credits { get; set; }
    }
}