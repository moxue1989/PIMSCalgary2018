using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivabilityCalculator
{
    public class Stat
    {
        public string Address { get; set; }
        public double LivabilityIndex { get; set; }
        public int CrimesCount { get; set; }
        public int SchoolsCount { get; set; }
        public int LibrariesCount { get; set; }
        public int ParkFeaturesCount { get; set; }
        public double AirQuality { get; set; }
    }
}
