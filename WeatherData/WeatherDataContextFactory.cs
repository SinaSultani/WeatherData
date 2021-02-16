using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WeatherData
{
    public class WeatherDataContextFactory : IDesignTimeDbContextFactory<WeatherDataDbContext>
    {
        public WeatherDataDbContext CreateDbContext(string[] args = null)
        {
            var configuartion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<WeatherDataDbContext>();

            //optionsBuilder.UseSqlServer(configuartion["ConnectionStrings:DefaultConnection"]);
            optionsBuilder.UseSqlServer(configuartion.GetConnectionString("DefaultConnection"));

            return new WeatherDataDbContext(optionsBuilder.Options);
        }
    }
}
