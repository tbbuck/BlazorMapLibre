using System.Text.Json.Serialization;
using Blazor.MapLibre.Models;

namespace Blazor.MapLibre
{
    public class Options
    {
        /// <summary>
        /// The inital geographical centerpoint of the map. If center is not specified in the constructor options,
        /// MapLibre GL JS will look for it in the map's style object. If it is not specified in the style, either,
        /// it will default to [0, 0] Note: MapLibre GL uses longitude, latitude coordinate order (as opposed to latitude, longitude) to match GeoJSON.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LngLat Center { get; set; }

        /// <summary>
        /// The HTML element in which Mapbox GL JS will render the map, or the element's string id . The specified element must have no children.
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        /// The minimum zoom level of the map (0-24).
        /// </summary>
        /// <remarks>
        /// default: 0
        /// </remarks>
        public int MinZoom { get; set; } = 0;

        /// <summary>
        /// The maximum zoom level of the map (0-24).
        /// </summary>
        /// <remarks>
        /// default: 22
        /// </remarks>
        public int MaxZoom { get; set; } = 22;

        public class DefaultStyles
        {
            public const string Streets = "https://api.maptiler.com/maps/streets-v2/style.json?key=DCan8FH7CG4gd7jJ68dv";
            // public const string Bright = "https://demotiles.maplibre.org/styles/osm-bright-gl-style/style.json";
            // public const string Terrain = "https://demotiles.maplibre.org/styles/osm-bright-gl-terrain/style.json";
        }

        /// <summary>
        /// The map's MapLibre style. This must be an a JSON object conforming to the schema described in the Mapbox Style Specification , or a URL to such JSON.
        /// </summary>
        public string Style { get; set; } = DefaultStyles.Streets;

        /// <summary>
        /// The initial zoom level of the map. If zoom is not specified in the constructor options, Mapbox GL JS will look for it in the map's style object. 
        /// If it is not specified in the style, either, it will default to 0.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Zoom { get; set; }
    }
}
