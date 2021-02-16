using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherData.Models;

namespace WeatherData
{
    public class WeatherDataDbContext : DbContext
    {
        public WeatherDataDbContext(DbContextOptions<WeatherDataDbContext> options) : base(options) { }

        public DbSet<Date> Dates { get; set; }
        public DbSet<Enviornment> Enviornments { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<Humidity> Humidities { get; set; }
        public DbSet<Mold> Molds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }


    }
}
