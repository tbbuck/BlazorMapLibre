using System.Text.Json.Serialization;

namespace Blazor.MapLibre.Models
{
    public class LngLat(decimal lng, decimal lat)
    {
        [JsonPropertyName("lat")]
        public decimal Lat { get; set; } = lat;

        [JsonPropertyName("lng")]
        public decimal Lng { get; set; } = lng;
    }
}
