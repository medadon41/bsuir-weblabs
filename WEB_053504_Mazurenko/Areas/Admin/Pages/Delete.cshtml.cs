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
    public class DeleteModel : PageModel
    {
        private readonly WEB_053504_Mazurenko.Data.ApplicationDbContext _context;

        private readonly IWebHostEnvironment _env;

        public DeleteModel(WEB_053504_Mazurenko.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cakes == null)
            {
                return NotFound();
            }
            var cake = await _context.Cakes.FindAsync(id);

            if (cake != null)
            {
                Cake = cake;

                string path = "/Images/" + cake.Image;
                System.IO.File.Delete(_env.WebRootPath + path);
                _context.Cakes.Remove(Cake);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
