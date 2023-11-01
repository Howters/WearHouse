using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WearHouse.Models;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
namespace WearHouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration config)
        {
            _configuration = config;
        }

        public IActionResult Index()
        {
            var key = _configuration.GetSection("0e0f8ebeb0cf105300ebf67ec6eef2be").Value;

            // API through RestSharp
            var client = new RestClient($"http://api.openweathermap.org/data/2.5/forecast?q=Jakarta&appid=&units=metric");
            var request = new RestRequest(RestSharp.Method.GET);
            IRestResponse responseCurrent = client.Execute(request);

            // Extended weather data
            var data = JObject.Parse(responseCurrent.Content);

            // Count of items in parsed JSON list
            var count = Convert.ToInt32(data["cnt"]);

            var list = new List<Weather>();

            // Loop through parsed JSON data from API and store each individual section into it's own object
            for (int i = 0; i < count; i += 8) // Pared down to only 5 days of forecast data for a more brief overview
            //for (int i = 0; i < count; i++) // Pared down to only 5 days of forecast data for a more brief overview
            {
                list.Add(new Weather()
                {
                    CityName = data["city"]["name"].ToString(),
                    TempMin = Convert.ToInt32(data["list"][i]["main"]["temp_min"]).ToString(),
                    TempMax = Convert.ToInt32(data["list"][i]["main"]["temp_max"]).ToString(),
                    Temp = (data["list"][i]["main"]["temp"]).ToString(),
                    Wicon = @"http://openweathermap.org/img/w/" + data["list"][i]["weather"][0]["icon"].ToString() + ".png",
                    Description = data["list"][i]["weather"][0]["description"].ToString().ToUpper(),
                    TimeStamp = data["list"][i]["dt_txt"].ToString(),
                    Country = data["city"]["country"].ToString(),
                    WindDirection = data["list"][i]["wind"]["deg"].ToString(),
                    Speed = Convert.ToInt32(data["list"][i]["wind"]["speed"]).ToString(),
                    Pop = Convert.ToInt32(data["list"][i]["pop"]).ToString()
                }
                );
            }

            for (int i = 0; i < list.Count; i++)
            {
                // Cardinal and Intercardinal directions

                // A lot of casting and converting here can probably be simplified but this was done quickly. Same goes for the IF statements...
                if (Convert.ToInt32(list[i].WindDirection) == 0 || Convert.ToInt32(list[i].WindDirection) == 360)
                    list[i].CardinalDirection = "Due North";
                if (Convert.ToInt32(list[i].WindDirection) == 45)
                    list[i].CardinalDirection = "NorthEast";
                if (Convert.ToInt32(list[i].WindDirection) == 90)
                    list[i].CardinalDirection = "Due East";
                if (Convert.ToInt32(list[i].WindDirection) == 135)
                    list[i].CardinalDirection = "SouthEast";
                if (Convert.ToInt32(list[i].WindDirection) == 180)
                    list[i].CardinalDirection = "Due South";
                if (Convert.ToInt32(list[i].WindDirection) == 215)
                    list[i].CardinalDirection = "SouthWest";
                if (Convert.ToInt32(list[i].WindDirection) == 270)
                    list[i].CardinalDirection = "Due West";
                if (Convert.ToInt32(list[i].WindDirection) == 315)
                    list[i].CardinalDirection = "NorthWest";


                if (Convert.ToInt32(list[i].WindDirection) < 90)
                    list[i].CardinalDirection = "NorthEast";
                else if (Convert.ToInt32(list[i].WindDirection) < 180)
                    list[i].CardinalDirection = "SouthEast";
                else if (Convert.ToInt32(list[i].WindDirection) < 270)
                    list[i].CardinalDirection = "SouthWest";
                else if (Convert.ToInt32(list[i].WindDirection) < 360)
                    list[i].CardinalDirection = "NorthWest";
            }

            ViewBag.Data = list;
            return View();
        }

   

        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}