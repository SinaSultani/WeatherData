using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherData.Models
{
    public class Mold
    {
        public int Id { get; set; }
        public float RiskForMold { get; set; }

        // Foreign Key

        public int TemperatureId { get; set; }
        public virtual Temperature Temperature { get; set; }

        public int HumidityId { get; set; }
        public virtual Humidity Humidity { get; set; }

    }
}
