using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherData.Models
{
    public class Humidity
    {
        public int Id { get; set; }

        public int AirHumidity { get; set; }

        //Foreign Key

        public int EnviornmentId { get; set; }
        public virtual Enviornment Enviornment { get; set; }
    }
}
