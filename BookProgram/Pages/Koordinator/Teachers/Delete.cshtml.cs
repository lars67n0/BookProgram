using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.Koordinator.Teachers
{
    public class DeleteModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public DeleteModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Teacher Teacher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Teacher == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher.FirstOrDefaultAsync(m => m.ID == id);

            if (teacher == null)
            {
                return NotFound();
            }
            else 
            {
                Teacher = teacher;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Teacher == null)
            {
                return NotFound();
            }
            var teacher = await _context.Teacher.FindAsync(id);

            if (teacher != null)
            {
                Teacher = teacher;
                _context.Teacher.Remove(Teacher);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
