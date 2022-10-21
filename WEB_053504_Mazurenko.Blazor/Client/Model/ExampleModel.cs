using System.ComponentModel.DataAnnotations;

namespace WEB_053504_Mazurenko.Blazor.Client.Model
{
    public class ExampleModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int? Counter { get; set; }
    }
}
