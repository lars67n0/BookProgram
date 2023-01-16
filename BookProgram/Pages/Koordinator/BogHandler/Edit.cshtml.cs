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

namespace BookProgram.Pages.Koordinator.BogHandler
{
    public class EditModel : PageModel
    {
        private readonly BookProgram.Data.BookProgramContext _context;

        public EditModel(BookProgram.Data.BookProgramContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Orders Orders { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders =  await _context.Orders.FirstOrDefaultAsync(m => m.ID == id);
            if (orders == null)
            {
                return NotFound();
            }
            Orders = orders;
           ViewData["BookListID"] = new SelectList(_context.BookList, "ID", "Author");
           ViewData["EducationID"] = new SelectList(_context.Education, "ID", "EducationName");
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

            _context.Attach(Orders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersExists(Orders.ID))
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

        private bool OrdersExists(int id)
        {
          return _context.Orders.Any(e => e.ID == id);
        }
    }
}
