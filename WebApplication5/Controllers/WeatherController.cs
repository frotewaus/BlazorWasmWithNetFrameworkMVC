using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    public class WeatherForecast
    {
        public string Date { get; set; }

        public int TemperatureC { get; set; }

        public string Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    public class WeatherController : Controller
    {
        public ActionResult Index()
        {
            var items = new List<WeatherForecast>();
            items.Add(new WeatherForecast { Date = "2021-01-02", TemperatureC = 33 });
            items.Add(new WeatherForecast { Date = "2022-05-12", TemperatureC = 25 });

            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}