using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookProgram.Pages.Account
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public Login Login { get; set; }
        public void OnGet()
        {


        }

        public async Task<IActionResult> OnpostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (Login.UserName == "admin" && Login.Password == "password")
            {



                // Koordinator Redirect
                return RedirectToPage("/Koordinator/Books/Index");

            }

            if (Login.UserName == "admin1" && Login.Password == "password1")
            {



                // Underviser Redirect
                return RedirectToPage("/Underviser/BookUnderviser/Index");

            }

            return Page();
        }

    }
    public class Login
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

