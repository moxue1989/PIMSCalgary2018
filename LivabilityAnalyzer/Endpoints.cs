using System;
using System.Collections.Generic;
using System.Text;

namespace LivabilityAnalyzer
{
    public class Endpoints
    {
        public const string CrimesUrl =
            "https://data.calgary.ca/resource/kudt-f99k.json?year=2018&$where=within_circle(community_center_point, " +
            "{0}, {1}, 1000)";

        public const string LibraryUrl =
            "https://data.calgary.ca/resource/j5v6-8bqr.json?$where=within_circle(location, " +
            "{0}, {1}, 4000)";

        public const string SchoolUrl =
            "https://data.calgary.ca/resource/gddc-smf3.json?$where=within_circle(location, " +
            "{0}, {1}, 1000)";

        public const string ParkFeatureUrl =
            "https://data.calgary.ca/resource/bw48-858t.json?$where=within_circle(location, " +
            "{0}, {1}, 1000)";

        public const string AirQualityUrl =
            "https://data.calgary.ca/resource/88iq-yi9x.json?parameter=Air Quality Index" +
            "&$where=date between '2018-03-1T12:00:00' and '2019-01-10T12:00:00' " +
            "and within_circle(location, {0}, {1}, 50000)";
    }
}
