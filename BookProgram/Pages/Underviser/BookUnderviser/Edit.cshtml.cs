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

namespace BookProgram.Pages.Underviser.BookUnderviser
{
    public class EditModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public EditModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BookList BookList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookList == null)
            {
                return NotFound();
            }

            var booklist =  await _context.BookList.FirstOrDefaultAsync(m => m.ID == id);
            if (booklist == null)
            {
                return NotFound();
            }
            BookList = booklist;
            return Page();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookListExists(BookList.ID))
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

        private bool BookListExists(int id)
        {
          return _context.BookList.Any(e => e.ID == id);
        }
    }
}
