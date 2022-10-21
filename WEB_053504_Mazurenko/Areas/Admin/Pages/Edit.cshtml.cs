using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using NuGet.Versioning;
using WEB_053504_Mazurenko.Data;
using WEB_053504_Mazurenko.Entites;

namespace WEB_053504_Mazurenko.Areas.Admin
{
    public class EditModel : PageModel
    {
        private readonly WEB_053504_Mazurenko.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EditModel(WEB_053504_Mazurenko.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [BindProperty]
        public Cake Cake { get; set; } = default!;

        [BindProperty]
        public IFormFile Image { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cakes == null)
            {
                return NotFound();
            }

            var cake =  await _context.Cakes.Include(g => g.Group).FirstOrDefaultAsync(m => m.Id == id);
            if (cake == null)
            {
                return NotFound();
            }
            var cakeGroups = await _context.CakeGroups.ToListAsync();
            Cake = cake;
            ViewData["CakeGroups"] = cakeGroups;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (Image != null)
            {
                string newFileName = Cake.Id + Path.GetExtension(Image.FileName);
                string path = "/Images/" + newFileName;
                
                using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                Cake.MimeType = Image.ContentType;
                Cake.Image = newFileName;
            } 
            else
            {
                string imageName = _context.Cakes.AsNoTracking().FirstOrDefault(x => x.Id == Cake.Id).Image;
                string mimeType = _context.Cakes.AsNoTracking().FirstOrDefault(x => x.Id == Cake.Id).MimeType;
                //_context.Entry(Cake).State = EntityState.Modified;
                Cake.Image = imageName;
                Cake.MimeType = mimeType;
            }

            //if (!ModelState.IsValid)
            //{
            //    var cakeGroups = await _context.CakeGroups.ToListAsync();
            //    ViewData["CakeGroups"] = cakeGroups;
            //    return Page();
            //}

            _context.Attach(Cake).State = EntityState.Modified;      

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CakeExists(Cake.Id))
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

        private bool CakeExists(int id)
        {
          return _context.Cakes.Any(e => e.Id == id);
        }
    }
}
