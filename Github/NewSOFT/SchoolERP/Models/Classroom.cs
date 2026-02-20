using System.Collections.Generic;

namespace SchoolERP.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;

        // Foreign Key linking to the Teacher
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        // Navigation property: A classroom can have many students
        public List<Student> Students { get; set; } = new();
    }
}