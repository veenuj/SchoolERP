using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Required to query the database
using SchoolERP.Data;               // Required to access SchoolContext
using SchoolERP.Services;
using System.Threading.Tasks;

namespace SchoolERP.Controllers
{
    public class SmartAssistantController : Controller
    {
        private readonly SmartAssistantService _aiService;
        private readonly SchoolContext _context;

        // .NET automatically injects BOTH your AI service and your Database here
        public SmartAssistantController(SmartAssistantService aiService, SchoolContext context)
        {
            _aiService = aiService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                ViewBag.Response = "Please enter a prompt.";
                return View();
            }

            // 1. Fetch the real student data from your PostgreSQL database
            var students = await _context.Students.ToListAsync();

            // 2. Format the data into a plain text string that the LLM can easily read
            string dataContext = "System Context - Current Enrolled Students:\n";
            if (students.Count == 0)
            {
                dataContext += "No students are currently enrolled in the database.\n";
            }
            else
            {
                foreach (var s in students)
                {
                    dataContext += $"- Name: {s.FirstName} {s.LastName} | Enrollment ID: {s.EnrollmentNumber}\n";
                }
            }

            // 3. Combine your raw database records with the user's actual question
            string engineeredPrompt = $@"{dataContext}

            User Question: {prompt}

            Instructions: Answer the user's question acting as a helpful school administrator. 
            Use ONLY the 'System Context' provided above to answer data-specific questions. 
            If the answer isn't in the system context, politely state that you don't have that information.";

            // 4. Send the perfectly formatted, data-rich prompt to Gemini
            string aiResponse = await _aiService.GenerateInsightAsync(engineeredPrompt);
            
            ViewBag.Response = aiResponse;
            ViewBag.OriginalPrompt = prompt; 
            
            return View();
        }
    }
}