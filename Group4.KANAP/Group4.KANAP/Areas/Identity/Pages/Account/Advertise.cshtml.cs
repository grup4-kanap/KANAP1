using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Group4.KANAP.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Group4.KANAP.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class AdvertiseModel : PageModel
    {
        private object _context;

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        public object AppUser { get; private set; }

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

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var emptyAdvertise = new AppUser();

            if (await TryUpdateModelAsync<AppUser>(emptyAdvertise,
                "advertise", 
                a => a.FirstName, a => a.LastName, a => a.Weight, a => a.BirthDay, a => a.BloodType, a => a.Rh ))
            {
                _context.AppUser.Add(emptyAdvertise);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
        }

    }
}