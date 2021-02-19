using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherData.Models;

namespace WeatherData.Controllers
{
    public class JoinMultipleTables : Controller
    {
        public IHttpActionResult GetTables()
        {
            WeatherDataDbContext wd = new WeatherDataDbContext();
            List<Date> ldates = wd.Dates.ToList();
            List<Enviornment> lenviornments = wd.Enviornments.ToList();
            List<Temperature> ltemperatures = wd.Temperatures.ToList();
            List<Humidity> lhumidities = wd.Humidities.ToList();
            List<Mold> lmolds = wd.Molds.ToList();
            var query = from d in ldates
                        join en in lenviornments on d.Id equals en.DateId into table1
                        from en in table1.DefaultIfEmpty()
                        join tp in ltemperatures on en.Id equals tp.EnviornmentId into table2
                        from tp in table2.DefaultIfEmpty()
                        select new JoinTables { GetDates = d, GetEnviornments = en, GetTemperatures = tp };
            return (IHttpActionResult)Ok(query);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
