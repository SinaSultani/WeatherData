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
            modelBuilder.Entity<Date>().HasData(

                new Date
                {
                    Id = 1,
                    TimeStamp = DateTime.Now
                },
                new Date
                {
                    Id = 2,
                    TimeStamp = DateTime.Now
                }, 
                new Date
                {
                    Id = 3,
                    TimeStamp = DateTime.Now
                },
                 new Date
                 {
                     Id = 4,
                     TimeStamp = DateTime.Now
                 }
                );
            modelBuilder.Entity<Enviornment>().HasData(

              new Enviornment
              {
                  Id = 1,
                  InsideOrOutside = "Outside",
                  DateId = 1
              },
              new Enviornment
              {
                  Id = 2,
                  InsideOrOutside = "Inside",
                  DateId = 2
              },
              new Enviornment
              {
                  Id = 3,
                  InsideOrOutside = "Outside",
                  DateId = 3
              },
              new Enviornment
              {
                  Id = 4,
                  InsideOrOutside = "Inside",
                  DateId = 4
              }             
              );
            modelBuilder.Entity<Humidity>().HasData(

              new Humidity
              {
                  Id = 1,
                  AirHumidity = 85,
                  EnviornmentId = 1
              },
              new Humidity
              {
                  Id = 2,
                  AirHumidity = 39,
                  EnviornmentId = 2
              },
              new Humidity
              {
                  Id = 3,
                  AirHumidity = 73,
                  EnviornmentId = 3
              },
              new Humidity
              {
                  Id = 4,
                  AirHumidity = 35,
                  EnviornmentId = 4
              }
              );
            modelBuilder.Entity<Temperature>().HasData(

              new Temperature
              {
                  Id = 1,
                  Temp = -5,
                  EnviornmentId = 1
              },
              new Temperature
              {
                  Id = 2,
                  Temp = 25,
                  EnviornmentId = 2
              },
              new Temperature
              {
                  Id = 3,
                  Temp = -2,
                  EnviornmentId = 3
              },
              new Temperature
              {
                  Id = 4,
                  Temp = 22,
                  EnviornmentId = 4
              }
              );
        }

    }
}
