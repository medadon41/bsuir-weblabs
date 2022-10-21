using Microsoft.AspNetCore.Mvc;
using WEB_053504_Mazurenko.Misc;
using WEB_053504_Mazurenko.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WEB_053504_Mazurenko.Components
{
    public class CartViewComponent : ViewComponent
    {
        private readonly Cart _cart;
        public CartViewComponent(Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            MenuItem cart = new MenuItem { Action = "Index", Controller = "Cart", Text = "0,00 руб (0)" };
            ViewData["Cart"] = _cart;
            return View(cart);
        }
    }
}
