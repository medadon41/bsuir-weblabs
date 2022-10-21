using System.ComponentModel.DataAnnotations;

namespace WEB_053504_Mazurenko.Entites
{
    public class CakeGroup
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
