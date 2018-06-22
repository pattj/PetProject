using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetProject.Models;

namespace PetProject.Pages.AnimalHomes
{
    public class DetailsModel : PageModel
    {
        private readonly PetProject.Models.pubsContext _context;

        public DetailsModel(PetProject.Models.pubsContext context)
        {
            _context = context;
        }

        public Shelters Shelters { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shelters = await _context.Shelters.FirstOrDefaultAsync(m => m.Id == id);

            if (Shelters == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
