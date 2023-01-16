using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.Koordinator.HoldYear
{
    public class DetailsModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public DetailsModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

      public Semester Semester { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Semester == null)
            {
                return NotFound();
            }

            var semester = await _context.Semester.FirstOrDefaultAsync(m => m.ID == id);
            if (semester == null)
            {
                return NotFound();
            }
            else 
            {
                Semester = semester;
            }
            return Page();
        }
    }
}
