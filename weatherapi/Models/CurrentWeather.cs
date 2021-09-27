using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace weatherapi.Models
{
    public class CurrentWeather
    {
        [JsonPropertyName("last_updated")]
        public string LastUpdated { get; init; }

        [JsonPropertyName("last_updated_epoch")]
        public int LastUpdatedEpoch { get; init; }

        [JsonPropertyName("temp_c")]
        public float Celsius { get; init; }

        [JsonPropertyName("temp_f")]
        public float Fahrenheit { get; init; }

        [JsonPropertyName("feelslike_c")]
        public float RealFeelInCelsius { get; init; }

        [JsonPropertyName("feelslike_f")]
        public float RealFeelInFahrenheit { get; init; }

        [JsonPropertyName("is_day")]
        public int IsDay { get; init; }

        [JsonPropertyName("wind_mph")]
        public float WindSpeedInMph { get; init; }

        [JsonPropertyName("wind_kph")]
        public float WindSpeedInKph { get; init; }

        [JsonPropertyName("wind_degree")]
        public int WindDirectionDegree { get; init; }

        [JsonPropertyName("wind_dir")]
        public string WindDirection { get; init; }

        [JsonPropertyName("pressure_mb")]
        public float PressureInMillibars { get; init; }

        [JsonPropertyName("pressure_in")]
        public float PressureInInches { get; init; }

        [JsonPropertyName("precip_mm")]
        public float PrecipitationInMilimeters { get; init; }

        [JsonPropertyName("precip_in")]
        public float PrecipitationInInches { get; init; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; init; }

        [JsonPropertyName("cloud")]
        public int Cloud { get; init; }

        [JsonPropertyName("uv")]
        public float UV { get; init; }

        [JsonPropertyName("gust_mph")]
        public float GustInMph { get; init; }

        [JsonPropertyName("gust_kph")]
        public float GustInKph { get; init; }
    }
}
