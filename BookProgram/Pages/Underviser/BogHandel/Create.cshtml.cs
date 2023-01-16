using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.Underviser.BogHandel
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
        ViewData["BookListID"] = new SelectList(_context.BookList, "ID", "Author");
        ViewData["EducationID"] = new SelectList(_context.Education, "ID", "EducationName");
            return Page();
        }

        [BindProperty]
        public Orders Orders { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          

            _context.Orders.Add(Orders);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
