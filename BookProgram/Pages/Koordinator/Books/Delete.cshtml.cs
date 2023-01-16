using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.Koordinator.Books
{
    public class DeleteModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public DeleteModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

        [BindProperty]
      public BookList BookList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookList == null)
            {
                return NotFound();
            }

            var booklist = await _context.BookList.FirstOrDefaultAsync(m => m.ID == id);

            if (booklist == null)
            {
                return NotFound();
            }
            else 
            {
                BookList = booklist;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BookList == null)
            {
                return NotFound();
            }
            var booklist = await _context.BookList.FindAsync(id);

            if (booklist != null)
            {
                BookList = booklist;
                _context.BookList.Remove(BookList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
