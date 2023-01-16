using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.Koordinator.HoldYear
{
    public class CreateModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public CreateModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EducationID"] = new SelectList(_context.Education, "ID", "EducationName");
        ViewData["TeacherID"] = new SelectList(_context.Teacher, "ID", "TeacherName");
            return Page();
        }

        [BindProperty]
        public Semester Semester { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          

            _context.Semester.Add(Semester);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
