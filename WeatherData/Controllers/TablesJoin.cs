using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using WeatherData.Models;

namespace WeatherData.Controllers
{
    public class TablesJoin : Controller
    {
        public IActionResult Index()
        {
            //ViewData["Results"] = TablesColumnsDisplay();
            return View();
        }

        public static void JoinTables()
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

            //public static List<JoinTables> TablesColumnsDisplay()
            //{
            //    List<JoinTables> jt = new List<JoinTables>();
            //    string connection = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = WeatherDataDb; Integrated Security = True";

            //    using (SqlConnection sqlconn = new SqlConnection(connection))
            //    {
            //        using (SqlCommand sqlcomm = new SqlCommand("select Dates.TimeStamp, Enviornments.InsideOrOutside, Temperatures.Temp, Humidities.AirHumidity, Molds.RiskForMold from Enviornments full join Date on Envoirnments.DateId=Date.DateId"))
            //        {

            //            using (SqlDataAdapter sda = new SqlDataAdapter())
            //            {
            //                sqlcomm.Connection = sqlconn;
            //                sqlconn.Open();
            //                sda.SelectCommand = sqlcomm;

            //                SqlDataReader sdr = sqlcomm.ExecuteReader();
            //                while (sdr.Read())
            //                {
            //                    JoinTables jtobj = new JoinTables();
            //                    jtobj.TimeStamp = (DateTime)sdr["TimeStamp"];
            //                    jtobj.InsideOrOutside = sdr["InsideOrOutSide"].ToString();
            //                    jtobj.Temp = (float)sdr["Temp"];
            //                    jtobj.AirHumidity = (int)sdr["AirHumidity"];
            //                    jtobj.RiskForMold = (float)sdr["RiskForMold"];
            //                    jt.Add(jtobj);

            //                }
            //            }
            //        return jt;
            //        }
            //    }
            //}
        }
    }
}
