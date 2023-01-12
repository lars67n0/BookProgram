using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.HoldList
{
    public class DeleteModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public DeleteModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Hold Hold { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hold == null)
            {
                return NotFound();
            }

            var hold = await _context.Hold.FirstOrDefaultAsync(m => m.ID == id);

            if (hold == null)
            {
                return NotFound();
            }
            else 
            {
                Hold = hold;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Hold == null)
            {
                return NotFound();
            }
            var hold = await _context.Hold.FindAsync(id);

            if (hold != null)
            {
                Hold = hold;
                _context.Hold.Remove(Hold);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
