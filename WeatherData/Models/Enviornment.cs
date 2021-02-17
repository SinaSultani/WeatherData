using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherData.Models
{
    public class Enviornment
    {
        public int Id { get; set; }

        //public string? Inside { get; set; }
        //public string? Outside { get; set; }
        public string InsideOrOutside { get; set; }


        //Foreign Key
        public int DateId { get; set; }
        public virtual Date Time { get; set; }

    }
}
