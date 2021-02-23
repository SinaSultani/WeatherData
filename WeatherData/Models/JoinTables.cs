using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WeatherData.Models;

namespace WeatherData
{
    public class JoinTables
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string InsideOrOutside { get; set; }
        public float Temp { get; set; }
        public int AirHumidity { get; set; }
        public float RiskForMold { get; set; }

        public static void JoiningTables()
        {
            using (var WeatherDataDbContext = new WeatherDataDbContext())
            {
                var datesData = WeatherDataDbContext.Dates
                    .Join(
                        WeatherDataDbContext.Enviornments,
                            date => date.Id,
                            enviornment => enviornment.Id,
                        (date, enviornment) => new
                        {
                            Id = date.Id,
                            TimeStamp = date.TimeStamp,
                            Enviornment = enviornment.InsideOrOutside
                        }
                    )
                    .Join(
                        WeatherDataDbContext.Temperatures,
                        date => date.Id,
                        temperature => temperature.Id,
                        (date, temperature) => new
                        {
                            Id = date.Id,
                            TimeStamp = date.TimeStamp,
                            Enviornment = date.Enviornment,
                            Temperature = temperature.Temp
                        }
                    )
                    .ToList();

            }
        }
    }
}
