﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherData;

namespace WeatherData.Migrations
{
    [DbContext(typeof(WeatherDataDbContext))]
    partial class WeatherDataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherData.Models.Date", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("WeatherData.Models.Enviornment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DateId")
                        .HasColumnType("int");

                    b.Property<string>("Inside")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Outside")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DateId");

                    b.ToTable("Enviornments");
                });

            modelBuilder.Entity("WeatherData.Models.Humidity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AirHumidity")
                        .HasColumnType("int");

                    b.Property<int>("EnviornmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnviornmentId");

                    b.ToTable("Humidities");
                });

            modelBuilder.Entity("WeatherData.Models.Mold", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HumidityId")
                        .HasColumnType("int");

                    b.Property<float>("RiskForMold")
                        .HasColumnType("real");

                    b.Property<int>("TemperatureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HumidityId");

                    b.HasIndex("TemperatureId");

                    b.ToTable("Molds");
                });

            modelBuilder.Entity("WeatherData.Models.Temperature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EnviornmentId")
                        .HasColumnType("int");

                    b.Property<float>("Temp")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("EnviornmentId");

                    b.ToTable("Temperatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EnviornmentId = 0,
                            Temp = 0f
                        });
                });

            modelBuilder.Entity("WeatherData.Models.Enviornment", b =>
                {
                    b.HasOne("WeatherData.Models.Date", "Time")
                        .WithMany()
                        .HasForeignKey("DateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Time");
                });

            modelBuilder.Entity("WeatherData.Models.Humidity", b =>
                {
                    b.HasOne("WeatherData.Models.Enviornment", "Enviornment")
                        .WithMany()
                        .HasForeignKey("EnviornmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enviornment");
                });

            modelBuilder.Entity("WeatherData.Models.Mold", b =>
                {
                    b.HasOne("WeatherData.Models.Humidity", "Humidity")
                        .WithMany()
                        .HasForeignKey("HumidityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeatherData.Models.Temperature", "Temperature")
                        .WithMany()
                        .HasForeignKey("TemperatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Humidity");

                    b.Navigation("Temperature");
                });

            modelBuilder.Entity("WeatherData.Models.Temperature", b =>
                {
                    b.HasOne("WeatherData.Models.Enviornment", "Enviornment")
                        .WithMany()
                        .HasForeignKey("EnviornmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enviornment");
                });
#pragma warning restore 612, 618
        }
    }
}
