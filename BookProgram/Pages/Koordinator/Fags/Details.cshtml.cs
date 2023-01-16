using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.Koordinator.Fags
{
    public class DetailsModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public DetailsModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

      public Fag Fag { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fag == null)
            {
                return NotFound();
            }

            var fag = await _context.Fag.FirstOrDefaultAsync(m => m.ID == id);
            if (fag == null)
            {
                return NotFound();
            }
            else 
            {
                Fag = fag;
            }
            return Page();
        }
    }
}
