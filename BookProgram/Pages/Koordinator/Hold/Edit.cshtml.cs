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

namespace BookProgram.Pages.Koordinator.Hold
{
    public class EditModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public EditModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Holds Holds { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hold == null)
            {
                return NotFound();
            }

            var holds =  await _context.Hold.FirstOrDefaultAsync(m => m.ID == id);
            if (holds == null)
            {
                return NotFound();
            }
            Holds = holds;
           ViewData["EducationID"] = new SelectList(_context.Education, "ID", "EducationName");
           ViewData["TeacherID"] = new SelectList(_context.Teacher, "ID", "TeacherName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Holds).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoldsExists(Holds.ID))
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

        private bool HoldsExists(int id)
        {
          return _context.Hold.Any(e => e.ID == id);
        }
    }
}
