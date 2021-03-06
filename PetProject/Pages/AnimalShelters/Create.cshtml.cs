using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetProject.Models;

namespace PetProject.Pages.AnimalShelters
{
    public class CreateModel : PageModel
    {
        private readonly PetProject.Models.PetProjectContext _context;

        public CreateModel(PetProject.Models.PetProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Shelters Shelters { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Shelters.Add(Shelters);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}