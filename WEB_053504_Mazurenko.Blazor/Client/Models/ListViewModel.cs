using System.Text.Json.Serialization;

namespace WEB_053504_Mazurenko.Blazor.Client.Models
{
    public class ListViewModel
    {
        [JsonPropertyName("id")]
        public int CakeId { get; set; }

        [JsonPropertyName("name")]
        public string CakeName { get; set; }  
    }
}
