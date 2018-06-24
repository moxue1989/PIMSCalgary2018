
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace LivabilityAnalyzer
{
    public static class Search
    {
        [FunctionName("Search")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string address = req.Query["address"];

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            address = address ?? data?.address;

            if (address == null)
            {
                return new BadRequestObjectResult("Please pass a address on the query string or in the request body");
            }

            Location location = GoogleLocator.GetLocationFromAddress(address);
            List<Crime> crimes = GetCrimes(location).OrderByDescending(c => c.Date).ToList();
            List<Library> libraries = GetLibraries(location);
            List<School> schools = GetSchools(location);
            List<AirQuality> airQualities = GetAirQuality(location);
            List<ParkFeature> parkFeatures = GetParkFeatures(location);

            List<double> topAirQualities = airQualities
                .OrderBy(a => Math.Pow(a.Location.Coordinates[1]-location.Latitude, 2) + 
                Math.Pow(a.Location.Coordinates[0] - location.Longitude, 2))
                .Select(a => double.Parse(a.AverageDailyValue))
                .Take(10)
                .ToList();

            double averageAirQuality = topAirQualities.Count > 0 ? topAirQualities.Average() : 2.5;

            int crimesCount = crimes.Count;
            int librariesCount = libraries.Count;
            int schoolsCount = schools.Count;
            int parkFeaturesCount = parkFeatures.Count;

            double livabilityIndex = CalculateLivabilityIndex(crimesCount, librariesCount, schoolsCount, parkFeaturesCount, averageAirQuality);

            return new OkObjectResult(new Result()
            {
                LivabilityIndex = livabilityIndex,
                Summary = $"{address} ({location.Latitude}, {location.Longitude})",
                Crimes = crimes.Take(10).ToList(),
                Schools = schools.Take(10).ToList(),
                Libraries = libraries.Take(10).ToList(),
                ParkFeatures = parkFeatures.Take(10).ToList(),
                AirQualities = airQualities.Take(10).ToList(),
                CrimesCount = crimesCount,
                SchoolsCount = schoolsCount,
                LibrariesCount = librariesCount,
                ParkFeaturesCount = parkFeaturesCount,
                AirQuality = averageAirQuality
            });
        }

        private static double CalculateLivabilityIndex(int crimesCount, int librariesCount, int schoolsCount, int parkFeaturesCount, double averageAirQuality)
        {
            double libraryScore = CalculateScore(1, 5, 0.3, 1, librariesCount) * 0.2;
            double schoolScore = CalculateScore(1, 5, 0.5, 1, schoolsCount) * 0.2;
            double crimeScore = CalculateScore(50, 200, 0.5, 1, crimesCount) * 0.4;
            double parkScore = CalculateScore(1, 100, 0.3, 1, parkFeaturesCount) * 0.2;
            double airQualityScore = Math.Min(averageAirQuality / 5.0 * 0.2, 0.2);
            return (libraryScore + schoolScore + parkScore + airQualityScore - crimeScore) * 100;
        }

        private static double CalculateScore(double x1, double x2, double y1, double y2, double input)
        {
            if (input <= 0 )
            {
                return 0;
            }
            var x = Math.Min(input, x2);

            double a = (y1 - y2)/Math.Log(x1/x2);
            double b = Math.Exp((y2 * Math.Log(x1) - y1 * Math.Log(x2)) / (y1 - y2));
            return a * Math.Log(b * x);
        }

        private static List<Crime> GetCrimes(Location location)
        {
            return Crime.FromJson(GetJsonData(location, Endpoints.CrimesUrl));
        }
        
        private static List<Library> GetLibraries(Location location)
        {
            return Library.FromJson(GetJsonData(location, Endpoints.LibraryUrl));
        }

        private static List<School> GetSchools(Location location)
        {
            return School.FromJson(GetJsonData(location, Endpoints.SchoolUrl));
        }

        private static List<AirQuality> GetAirQuality(Location location)
        {
            return AirQuality.FromJson(GetJsonData(location, Endpoints.AirQualityUrl));
        }

        private static List<ParkFeature> GetParkFeatures(Location location)
        {
            return ParkFeature.FromJson(GetJsonData(location, Endpoints.ParkFeatureUrl));
        }

        private static string GetJsonData(Location location, string baseUrl)
        {
            HttpClient client = GetNewClient();
            string endpoint = string.Format(baseUrl, location.Latitude, location.Longitude);
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        private static HttpClient GetNewClient()
        {
            return new HttpClient();
        }
    }
}
