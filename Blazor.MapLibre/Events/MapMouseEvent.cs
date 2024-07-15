using System.Text.Json.Serialization;
using Blazor.MapLibre.Models;

namespace Blazor.MapLibre.Events
{
    public class MapMouseEvent : BaseEvent
    {
        [JsonPropertyName("lngLat")]
        public LngLat LngLat { get; set; }

        [JsonPropertyName("point")]
        public Point Point { get; set; }

        [JsonPropertyName("features")]
        public Feature[] Features { get; set; }
    }
}
