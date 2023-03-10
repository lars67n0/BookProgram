using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.Koordinator.Educations
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
            return Page();
        }

        [BindProperty]
        public Education Education { get; set; }
        

        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Education.Add(Education);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
