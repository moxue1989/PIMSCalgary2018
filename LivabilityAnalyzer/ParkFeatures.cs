using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LivabilityAnalyzer
{
    public partial class ParkFeature
    {
        [JsonProperty("asset_cd")]
        public string AssetCd { get; set; }

        [JsonProperty("asset_class")]
        public string AssetClass { get; set; }

        [JsonProperty("asset_type")]
        public string AssetType { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("life_cycle_status")]
        public string LifeCycleStatus { get; set; }

        [JsonProperty("location")]
        public ParkLocation Location { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("maintained_by")]
        public string MaintainedBy { get; set; }

        [JsonProperty("steward")]
        public string Steward { get; set; }
    }

    public class ParkLocation
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public partial class ParkFeature
    {
        public static List<ParkFeature> FromJson(string json) => JsonConvert.DeserializeObject<List<ParkFeature>>(json);
    }
}
