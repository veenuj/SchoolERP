using SchoolERP.Models;
using System;
using System.Linq;

namespace SchoolERP.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            // Ensure DB is ready
            context.Database.EnsureCreated();

            if (context.Students.Any()) return;

            // 1. Subjects
            var subjects = new Subject[]
            {
                new Subject { Name = "Mathematics", Code = "MATH101", Credits = 5 },
                new Subject { Name = "Physics", Code = "PHY201", Credits = 4 },
                new Subject { Name = "History", Code = "HIS101", Credits = 3 },
                new Subject { Name = "English", Code = "ENG101", Credits = 3 }
            };
            context.Subjects.AddRange(subjects);
            context.SaveChanges();

            // 2. Teachers (Using UtcNow)
            string[] depts = { "Science", "Commerce", "Arts", "Languages" };
            for (int i = 1; i <= 20; i++)
            {
                context.Teachers.Add(new Teacher
                {
                    FirstName = $"Teacher_{i}",
                    LastName = "Staff",
                    Email = $"teacher{i}@school.edu",
                    Department = depts[i % depts.Length],
                    HireDate = DateTime.UtcNow.AddYears(-i) // FIX: UtcNow
                });
            }
            context.SaveChanges();

            // 3. Students (Including DOB and UtcNow)
            string[] grades = { "LKG", "10th", "12th (Science)", "12th (Commerce)", "12th (Arts)" };
            Random rnd = new Random();
            for (int i = 1; i <= 200; i++)
            {
                context.Students.Add(new Student
                {
                    FirstName = $"Student_{i}",
                    LastName = "Doe",
                    EnrollmentNumber = $"STU{1000 + i}",
                    Grade = grades[rnd.Next(grades.Length)],
                    EnrollmentDate = DateTime.UtcNow.AddMonths(-rnd.Next(1, 12)), // FIX: UtcNow
                    DateOfBirth = DateTime.UtcNow.AddYears(-rnd.Next(5, 18)) // FIX: DOB Added
                });
            }
            context.SaveChanges();
            
            // 4. Payroll
            var teachers = context.Teachers.ToList();
            foreach (var t in teachers)
            {
                context.Payrolls.Add(new Payroll {
                    TeacherId = t.Id,
                    Month = "February",
                    Year = 2026,
                    BaseSalary = 50000,
                    Allowances = 5000,
                    Deductions = 2000,
                    PaymentDate = DateTime.UtcNow, // FIX: UtcNow
                    IsPaid = true
                });
            }
            context.SaveChanges();
        }
    }
}