using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public IndexModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

        public IList<BookList> BookList { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BookList != null)
            {
                BookList = await _context.BookList.ToListAsync();
            }
        }
    }
}
