using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherData.Models;

namespace WeatherData
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Temperature>().HasData(

                new Temperature
                {
                    Id = 1,
                    //Name = "Malmö"
                }
                );
        }

    }
}
