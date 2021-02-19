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

        public DateTime TimeStamp { get; set; }
        public string InsideOrOutside { get; set; }
        public float Temp { get; set; }
        public int AirHumidity { get; set; }
        public float RiskForMold { get; set; }
    }
}
