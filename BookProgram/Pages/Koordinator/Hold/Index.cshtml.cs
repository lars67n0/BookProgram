using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.Koordinator.Hold
{
    public class IndexModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public IndexModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

        public IList<Holds> Holds { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Hold != null)
            {
                Holds = await _context.Hold
                .Include(h => h.Education)
                .Include(h => h.Teacher).ToListAsync();
            }
        }
    }
}
