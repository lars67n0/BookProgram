using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.Koordinator.Fags
{
    public class DeleteModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public DeleteModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Fag Fag { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fag == null)
            {
                return NotFound();
            }

            var fag = await _context.Fag.FirstOrDefaultAsync(m => m.ID == id);

            if (fag == null)
            {
                return NotFound();
            }
            else 
            {
                Fag = fag;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Fag == null)
            {
                return NotFound();
            }
            var fag = await _context.Fag.FindAsync(id);

            if (fag != null)
            {
                Fag = fag;
                _context.Fag.Remove(Fag);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
