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
    public class IndexModel : PageModel
    {
        private readonly WEB_053504_Mazurenko.Data.ApplicationDbContext _context;

        public IndexModel(WEB_053504_Mazurenko.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Cake> Cake { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cakes != null)
            {
                Cake = await _context.Cakes.Include(g => g.Group).ToListAsync();
            }
        }
    }
}
