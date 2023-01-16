using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookProgram.Data;
using BookProgram.Model;

namespace BookProgram.Pages.Koordinator.Educations
{
    public class DetailsModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public DetailsModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

      public Education Education { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Education == null)
            {
                return NotFound();
            }

            var education = await _context.Education.FirstOrDefaultAsync(m => m.ID == id);
            if (education == null)
            {
                return NotFound();
            }
            else 
            {
                Education = education;
            }
            return Page();
        }
    }
}
