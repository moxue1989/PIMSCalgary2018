using System;
using System.Collections.Generic;
using System.Text;

namespace LivabilityAnalyzer
{
    public class Result
    {
        public double LivabilityIndex { get; set; }
        public string Summary { get; set; }
        public int CrimesCount { get; set; }
        public int SchoolsCount { get; set; }
        public int LibrariesCount { get; set; }
        public int ParkFeaturesCount { get; set; }
        public double AirQuality { get; set; }
        public List<Crime> Crimes { get; set; }
        public List<School> Schools { get; set; }
        public List<Library> Libraries { get; set; }
        public List<ParkFeature> ParkFeatures { get; set; }
        public List<AirQuality> AirQualities { get; set; }
    }
}
