using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using WEB_053504_Mazurenko.Entites;

namespace WEB_053504_Mazurenko.Controllers
{
    public class ImageController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        public ImageController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> GetAvatar([FromServices] IWebHostEnvironment env)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user.Image == null)
            {
                var provider = env.WebRootFileProvider;
                var path = Path.Combine("Images", "avatar.jpg");
                var fInfo = provider.GetFileInfo(path);
                var ext = Path.GetExtension(fInfo.Name);
                var extProvider = new FileExtensionContentTypeProvider();
                return File(fInfo.CreateReadStream(), extProvider.Mappings[ext]);
            }

            MemoryStream ms = new MemoryStream(user.Image);
            return File(ms, user.MimeType);
        }
    }
}
