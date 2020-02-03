using Core.Entities.Booking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
    public class HotelDBContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        private readonly IConfiguration configuration;
        public HotelDBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("Default"));
        }
    }
}
