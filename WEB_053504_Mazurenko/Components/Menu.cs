using Microsoft.AspNetCore.Mvc;
using WEB_053504_Mazurenko.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WEB_053504_Mazurenko.Components
{
    public class Menu : ViewComponent
    {
        List<MenuItem> items = new List<MenuItem>();

        private List<MenuItem> _menuItems = new List<MenuItem>
        {
        new MenuItem{ Controller="Home", Action="Index", Text="Lab 3"},
        new MenuItem{ Controller="Cake", Action="Index", Text="Каталог"},
        new MenuItem{ IsPage=true, Area="Admin", Page="/Index", Text="Администрирование"}
        };

        public IViewComponentResult Invoke()
        {
            foreach (MenuItem item in _menuItems)
            {
                if (item.Controller == ViewContext.RouteData.Values["controller"] || item.Area == ViewContext.RouteData.Values["area"])
                {
                    item.Active = "active";
                }

                items.Add(item);
            }

            return View(items);
        }
    }
}
