using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.Koordinator.Educations
{
    public class EditModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public EditModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Education Education { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Education == null)
            {
                return NotFound();
            }

            var education =  await _context.Education.FirstOrDefaultAsync(m => m.ID == id);
            if (education == null)
            {
                return NotFound();
            }
            Education = education;
            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Education).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EducationExists(Education.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EducationExists(int id)
        {
          return _context.Education.Any(e => e.ID == id);
        }
    }
}
