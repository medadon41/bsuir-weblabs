using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_053504_Mazurenko.Data;
using WEB_053504_Mazurenko.Misc;

namespace WEB_053504_Mazurenko.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly Cart _cart;

        public CartController(ApplicationDbContext context, Cart cart)
        {
            _context = context;
            _cart = cart;
        }

        [Authorize]
        public IActionResult Add(int id, string returnUrl)
        {
            var cart = HttpContext.Session.Get<Cart>("cart") ?? new Cart();
            var cake = _context.Cakes.Find(id);
            if (cake != null)
            {
                cart.AddToCart(cake);
                HttpContext.Session.Set<Cart>("cart", cart);
            }
            return Redirect(returnUrl);
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var cart = HttpContext.Session.Get<Cart>("cart") ?? new Cart();
            cart.RemoveFromCart(id);
            HttpContext.Session.Set<Cart>("cart", cart);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<Cart>("cart") ?? new Cart();
            return View(cart.Items);
        }

    }
}
