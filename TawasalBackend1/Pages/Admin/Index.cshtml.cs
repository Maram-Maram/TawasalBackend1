using Microsoft.AspNetCore.Mvc.RazorPages;
using TawasalBackend1.Data;
using TawasalBackend1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TawasalBackend1.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _context;

        public IndexModel(ApplicationDBContext context)
        {
            _context = context;
        }
        
        public IList<User> Users { get; private set; }

        public async Task OnGetAsync()
        {
            if (_context.Users != null)
            {
                Users = await _context.Users.ToListAsync();
            }
            else
            {
                Users = new List<User>();
            }
        }
    }
}
