using System.ComponentModel.DataAnnotations;

namespace WEB_053504_Mazurenko.Entites
{
    public class Cake
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CakeGroup Group { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }

        public string MimeType { get; set; }
    }
}
