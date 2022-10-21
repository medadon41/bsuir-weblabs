using Microsoft.AspNetCore.Identity;

namespace WEB_053504_Mazurenko.Entites
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] Image { get; set; }

        public string MimeType { get; set; }
    }
}
