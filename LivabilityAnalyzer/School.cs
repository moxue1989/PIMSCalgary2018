using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LivabilityAnalyzer
{
    public partial class School
    {
        [JsonProperty("address_ab")]
        public string AddressAb { get; set; }

        [JsonProperty("board")]
        public string Board { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("data_source")]
        public string DataSource { get; set; }

        [JsonProperty("ecs")]
        public string Ecs { get; set; }

        [JsonProperty("elem")]
        public string Elem { get; set; }

        [JsonProperty("grades")]
        public string Grades { get; set; }

        [JsonProperty("junior_h")]
        public string JuniorH { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("location")]
        public SchoolLocation Location { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("name_ab")]
        public string NameAb { get; set; }

        [JsonProperty("postal_cod")]
        public string PostalCod { get; set; }

        [JsonProperty("postsecond")]
        public string Postsecond { get; set; }

        [JsonProperty("process_dt")]
        public DateTimeOffset ProcessDt { get; set; }

        [JsonProperty("province")]
        public string Province { get; set; }

        [JsonProperty("provincial_code_num")]
        public string ProvincialCodeNum { get; set; }

        [JsonProperty("senior_h")]
        public string SeniorH { get; set; }

        [JsonProperty("structure_id")]
        public string StructureId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class SchoolLocation
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public partial class School
    {
        public static List<School> FromJson(string json) => JsonConvert.DeserializeObject<List<School>>(json);
    }
}
