using Microsoft.AspNetCore.Mvc.RazorPages;
using TawasalBackend1.Data;
using TawasalBackend1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace TawasalBackend1.Pages.Admin.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public IndexModel(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Course> Courses { get; set; } = new List<Course>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            // Retrieve all courses or filter by search term
            if (string.IsNullOrEmpty(SearchTerm))
            {
                Courses = await _context.Courses.ToListAsync();
            }
            else
            {
                Courses = await _context.Courses
                    .Where(c => c.Title.Contains(SearchTerm) || c.Description.Contains(SearchTerm))
                    .ToListAsync();
            }
        }
    }
}
