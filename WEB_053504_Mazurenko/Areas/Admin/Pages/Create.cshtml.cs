using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEB_053504_Mazurenko.Data;
using WEB_053504_Mazurenko.Entites;

namespace WEB_053504_Mazurenko.Areas.Admin
{
    public class CreateModel : PageModel
    {
        private readonly WEB_053504_Mazurenko.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CreateModel(WEB_053504_Mazurenko.Data.ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> OnGet()
        {
            var cakeGroups = await _context.CakeGroups.ToListAsync();
            ViewData["CakeGroups"] = cakeGroups;
            return Page();
        }

        [BindProperty]
        public Cake Cake { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; }

        [BindProperty]
        public int CakeGroupId { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (Image != null)
            {
                int lastId = _context.Cakes.OrderBy(x => x.Id).Last().Id;
                string newFileName = ++lastId + Path.GetExtension(Image.FileName);
                string path = "/Images/" + newFileName;

                using (var fileStream = new FileStream(_env.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                Cake.MimeType = Image.ContentType;
                Cake.Image = newFileName;
            }

            var cakeGroup = await _context.CakeGroups.FirstOrDefaultAsync(x => x.Id == CakeGroupId);
            Cake.Group = cakeGroup;

            //if (!ModelState.IsValid)
            //{
            //    var cakeGroups = await _context.CakeGroups.ToListAsync();
            //    ViewData["CakeGroups"] = cakeGroups;
            //    return Page();
            //}

            _context.Add(Cake);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
