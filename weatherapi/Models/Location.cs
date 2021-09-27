using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace weatherapi.Models
{
    public class Location
    {
        [JsonPropertyName("lat")]
        public decimal Latitude { get; init; }

        [JsonPropertyName("lon")]
        public decimal Longitude { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("region")]
        public string Region { get; init; }

        [JsonPropertyName("country")]
        public string Country { get; init; }

        [JsonPropertyName("tz_id")]
        public string Timezone { get; init; }

        [JsonPropertyName("localtime_epoch")]
        public int LocalTimeEpoch { get; init; }

        [JsonPropertyName("localtime")]
        public string LocalTime { get; init; }
    }
}
