using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Required for async database queries
using SchoolERP.Data;               // Required to access your database
using SchoolERP.Models;

namespace SchoolERP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SchoolContext _context;

        // .NET automatically injects the database context here
        public HomeController(ILogger<HomeController> logger, SchoolContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Query the live database for actual row counts
            ViewBag.TotalStudents = await _context.Students.CountAsync();
            ViewBag.TotalTeachers = await _context.Teachers.CountAsync();
            ViewBag.TotalClassrooms = await _context.Classrooms.CountAsync();
            ViewBag.TotalSubjects = await _context.Subjects.CountAsync();
            // Since we aren't saving AI chats to the DB yet, we will set this to 0 for now
            ViewBag.TotalAIInsights = 0; 

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}