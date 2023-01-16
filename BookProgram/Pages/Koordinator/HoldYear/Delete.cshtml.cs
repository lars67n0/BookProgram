using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.Koordinator.HoldYear
{
    public class DeleteModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public DeleteModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Semester Semester { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Semester == null)
            {
                return NotFound();
            }

            var semester = await _context.Semester.FirstOrDefaultAsync(m => m.ID == id);

            if (semester == null)
            {
                return NotFound();
            }
            else 
            {
                Semester = semester;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Semester == null)
            {
                return NotFound();
            }
            var semester = await _context.Semester.FindAsync(id);

            if (semester != null)
            {
                Semester = semester;
                _context.Semester.Remove(Semester);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
