using Microsoft.AspNetCore.Mvc;
using WEB_053504_Mazurenko.Data;
using WEB_053504_Mazurenko.Entites;
using WEB_053504_Mazurenko.Models;
using WEB_053504_Mazurenko.Misc;
using Microsoft.VisualBasic;
using Serilog;

namespace WEB_053504_Mazurenko.Controllers
{
    public class CakeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private const int _pageSize = 3;

        public CakeController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        [Route("Catalog/Group_{group}")]
        [Route("Catalog/Group_{group}/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            var model = ListViewModel<Cake>.GetModel(_context.Cakes, pageNo, _pageSize, x => !group.HasValue || x.Group.Id == group.Value);
            var cakeGroups = _context.CakeGroups.ToList();
            ViewData["Groups"] = cakeGroups;
            ViewData["CurrentGroup"] = group ?? 0;

            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
    }
}
