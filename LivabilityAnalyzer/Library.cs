using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LivabilityAnalyzer
{
    public partial class Library
    {
        [JsonProperty("friday_close")]
        public string FridayClose { get; set; }

        [JsonProperty("friday_open")]
        public string FridayOpen { get; set; }

        [JsonProperty("library")]
        public string LibraryLibrary { get; set; }

        [JsonProperty("location")]
        public LibraryLocation Location { get; set; }

        [JsonProperty("location_1")]
        public LibraryLocation Location1 { get; set; }

        [JsonProperty("location_1_address")]
        public string Location1Address { get; set; }

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

    public class LibraryLocation
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<double> Coordinates { get; set; }
    }

    public partial class Library
    {
        public static List<Library> FromJson(string json) => JsonConvert.DeserializeObject<List<Library>>(json);
    }
}
