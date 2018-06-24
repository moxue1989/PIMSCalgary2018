using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LivabilityAnalyzer
{
    public partial class AirQuality
    {
        [JsonProperty("average_daily_value")]
        public string AverageDailyValue { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("location")]
        public AirQualityLocation Location { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("parameter")]
        public string Parameter { get; set; }

        [JsonProperty("station_name")]
        public string StationName { get; set; }
    }

    public class AirQualityLocation
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public partial class AirQuality
    {
        public static List<AirQuality> FromJson(string json) => JsonConvert.DeserializeObject<List<AirQuality>>(json);
    }
}
