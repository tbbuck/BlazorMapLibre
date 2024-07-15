using System.Text.Json.Serialization;

namespace Blazor.MapLibre.Events
{
    public class BaseEvent
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
