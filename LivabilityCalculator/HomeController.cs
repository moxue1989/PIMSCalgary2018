using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LivabilityCalculator
{
    public class HomeController : Controller
    {
        public const string BaseUrl =
                "https://pimshacker.azurewebsites.net/api/Search?code=as3To2FlB86O9vz5papSWzxVUHxDhy/meNdGeCDZKbkilqBtf7wPjQ==&address="
            ;

        public static ConcurrentBag<Stat> RecentStats = new ConcurrentBag<Stat>();

        public static List<Stat> Stats = new List<Stat>()
        {
            new Stat
            {
                Address = "Killarney (51.0315718, -114.1335238)",
                LivabilityIndex = 26.298112435126352,
                CrimesCount = 65,
                LibrariesCount = 3,
                SchoolsCount = 3,
                ParkFeaturesCount = 1,
                AirQuality = 2.92517
            },
            new Stat
            {
                Address = "Tuscany (51.1235364, -114.2448431)",
                LivabilityIndex = 25.624363468292856,
                CrimesCount = 46,
                LibrariesCount = 1,
                SchoolsCount = 4,
                ParkFeaturesCount = 2,
                AirQuality = 2.92517
            },
            new Stat
            {
                Address = "Edgemont (51.1199283, -114.1475829)",
                LivabilityIndex = 22.987954520550847,
                CrimesCount = 56,
                LibrariesCount = 2,
                SchoolsCount = 1,
                ParkFeaturesCount = 5,
                AirQuality = 2.92517
            },
            new Stat
            {
                Address = "Airport (51.1297881, -114.0063068)",
                LivabilityIndex = -6.0578490655494992,
                CrimesCount = 45,
                LibrariesCount = 0,
                SchoolsCount = 0,
                ParkFeaturesCount = 0,
                AirQuality = 3.1055300000000003
            },
            new Stat
            {
                Address = "Acadia (50.9702586, -114.0596485",
                LivabilityIndex = 23.331924052769356,
                CrimesCount = 69,
                LibrariesCount = 3,
                SchoolsCount = 8,
                ParkFeaturesCount = 0,
                AirQuality = 3.1055300000000003
            },
            new Stat
            {
                Address = "Beltline (51.0413217, -114.0889692)",
                LivabilityIndex = 33.921288423892513,
                CrimesCount = 160,
                LibrariesCount = 5,
                SchoolsCount = 6,
                ParkFeaturesCount = 72,
                AirQuality = 2.92517
            },
            new Stat
            {
                Address = "Sundance (51.0413217, -114.0889692)",
                LivabilityIndex = 33.921288423892513,
                CrimesCount = 58,
                LibrariesCount = 1,
                SchoolsCount = 5,
                ParkFeaturesCount = 27,
                AirQuality = 3.45802
            }
        };

        public IActionResult Index()
        {
            List<Stat> stats = Stats.ToList();
            return View(stats);
        }

        public Result Search(string address)
        {
            HttpClient client = new HttpClient();
            string endpoint = BaseUrl + address;
            HttpResponseMessage response = client.GetAsync(endpoint).Result;
            string jsonResult = response.Content.ReadAsStringAsync().Result;

            Result result = Result.FromJson(jsonResult);

            Stat stat = new Stat()
            {
                Address = result.Summary,
                AirQuality = result.AirQuality,
                CrimesCount = result.CrimesCount,
                LibrariesCount = result.LibrariesCount,
                SchoolsCount = result.SchoolsCount,
                ParkFeaturesCount = result.ParkFeaturesCount,
                LivabilityIndex = result.LivabilityIndex
            };

            RecentStats.Add(stat);
            result.RecentStats = RecentStats.TakeLast(10).ToList();
            return result;
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
