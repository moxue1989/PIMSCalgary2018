using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LivabilityAnalyzer
{
    public partial class Crime
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("community_center_point")]
        public CommunityCenterPoint CommunityCenterPoint { get; set; }

        [JsonProperty("community_name")]
        public string CommunityName { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("month")]
        public string Month { get; set; }

        [JsonProperty("sector")]
        public string Sector { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }
    }

    public class CommunityCenterPoint
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public partial class Crime
    {
        public static List<Crime> FromJson(string json) => JsonConvert.DeserializeObject<List<Crime>>(json);
    }
}
