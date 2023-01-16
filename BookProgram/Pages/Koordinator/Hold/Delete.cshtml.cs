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
    public class DeleteModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public DeleteModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Holds Holds { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hold == null)
            {
                return NotFound();
            }

            var holds = await _context.Hold.FirstOrDefaultAsync(m => m.ID == id);

            if (holds == null)
            {
                return NotFound();
            }
            else 
            {
                Holds = holds;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Hold == null)
            {
                return NotFound();
            }
            var holds = await _context.Hold.FindAsync(id);

            if (holds != null)
            {
                Holds = holds;
                _context.Hold.Remove(Holds);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
