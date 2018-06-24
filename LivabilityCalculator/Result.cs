using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Newtonsoft.Json;

namespace LivabilityCalculator
{
    public partial class Result
    {
        [JsonProperty("LivabilityIndex")]
        public double LivabilityIndex { get; set; }

        [JsonProperty("Summary")]
        public string Summary { get; set; }

        [JsonProperty("CrimesCount")]
        public int CrimesCount { get; set; }

        [JsonProperty("SchoolsCount")]
        public int SchoolsCount { get; set; }

        [JsonProperty("LibrariesCount")]
        public int LibrariesCount { get; set; }

        [JsonProperty("ParkFeaturesCount")]
        public int ParkFeaturesCount { get; set; }

        [JsonProperty("AirQuality")]
        public double AirQuality { get; set; }

        [JsonProperty("Crimes")]
        public List<Crime> Crimes { get; set; }

        [JsonProperty("Schools")]
        public List<School> Schools { get; set; }

        [JsonProperty("Libraries")]
        public List<Library> Libraries { get; set; }

        [JsonProperty("ParkFeatures")]
        public List<ParkFeature> ParkFeatures { get; set; }

        [JsonProperty("AirQualities")]
        public List<AirQuality> AirQualities { get; set; }

        [JsonProperty("RecentStats")]
        public List<Stat> RecentStats { get; set; }
    }

    public partial class AirQuality
    {
        [JsonProperty("average_daily_value")]
        public string AverageDailyValue { get; set; }

        [JsonProperty("count")]
        public string Count { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("parameter")]
        public string Parameter { get; set; }

        [JsonProperty("station_name")]
        public string StationName { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public partial class Result
    {
        public static Result FromJson(string json) => JsonConvert.DeserializeObject<Result>(json);
    }

    public partial class Crime
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("community_center_point")]
        public Location CommunityCenterPoint { get; set; }

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

    public partial class Library
    {
        [JsonProperty("friday_close")]
        public string FridayClose { get; set; }

        [JsonProperty("friday_open")]
        public string FridayOpen { get; set; }

        [JsonProperty("library")]
        public string LibraryLibrary { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("location_1")]
        public Location Location1 { get; set; }

        [JsonProperty("location_1_address")]
        public string Location1_Address { get; set; }

        [JsonProperty("monday_close")]
        public string MondayClose { get; set; }

        [JsonProperty("monday_open")]
        public string MondayOpen { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("saturday_close")]
        public string SaturdayClose { get; set; }

        [JsonProperty("saturday_open")]
        public string SaturdayOpen { get; set; }

        [JsonProperty("square_feet")]
        public string SquareFeet { get; set; }

        [JsonProperty("sunday_close")]
        public string SundayClose { get; set; }

        [JsonProperty("sunday_open")]
        public string SundayOpen { get; set; }

        [JsonProperty("thursday_close")]
        public string ThursdayClose { get; set; }

        [JsonProperty("thursday_open")]
        public string ThursdayOpen { get; set; }

        [JsonProperty("tuesday_close")]
        public string TuesdayClose { get; set; }

        [JsonProperty("tuesday_open")]
        public string TuesdayOpen { get; set; }

        [JsonProperty("wednesday_close")]
        public string WednesdayClose { get; set; }

        [JsonProperty("wednesday_open")]
        public string WednesdayOpen { get; set; }
    }

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
        public Location Location { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("maintained_by")]
        public string MaintainedBy { get; set; }

        [JsonProperty("steward")]
        public string Steward { get; set; }
    }

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
        public Location Location { get; set; }

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
}
