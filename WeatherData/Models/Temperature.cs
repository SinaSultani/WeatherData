using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherData.Models
{
    public class Temperature
    {
        public int Id { get; set; }

        public float Temp { get; set; }

        // Foreign Key
        
        public int EnviornmentId { get; set; }
        public virtual Enviornment Enviornment { get; set; }
    }
}
