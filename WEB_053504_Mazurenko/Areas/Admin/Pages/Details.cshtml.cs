using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WEB_053504_Mazurenko.Data;
using WEB_053504_Mazurenko.Entites;

namespace WEB_053504_Mazurenko.Areas.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly WEB_053504_Mazurenko.Data.ApplicationDbContext _context;

        public DetailsModel(WEB_053504_Mazurenko.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Cake Cake { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cakes == null)
            {
                return NotFound();
            }

            var cake = await _context.Cakes.FirstOrDefaultAsync(m => m.Id == id);
            if (cake == null)
            {
                return NotFound();
            }
            else 
            {
                Cake = cake;
            }
            return Page();
        }
    }
}
