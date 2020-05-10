using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group4.KANAP.Areas.Identity.Pages.Account
{
    public class ShowAdvertiseModel : PageModel
    {
        private object _context;

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Ad")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Soyad")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Kilo")]
            public string Weight { get; set; }

            [Display(Name = "Doğum Tarihi")]
            public DateTime? BirthDay { get; set; }

            [Display(Name = "Kan Grubu")]
            public string BloodType { get; set; }

            [Display(Name = "Rh")]
            public string Rh { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser = await _context.AppUser
                .Include(a => a.Ad)
                .ThenInclude(a => a.BloodType)
                .ThenInclude(a => a.TelephoneNumber)
                .ThenInclude(a => a.Email)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (AppUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}