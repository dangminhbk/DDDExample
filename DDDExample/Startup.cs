using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Core.Command;
using Microsoft.OpenApi.Models;
using Infrastructure.EventStore;
using Core.Domain.Booking;
using Core.Data;
using Microsoft.EntityFrameworkCore;

namespace DDDExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HotelDBContext>(s=> {
                s.UseNpgsql(Configuration.GetConnectionString("Default"));
            });
            services.AddRazorPages();
            services.AddControllers();          
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            AddMeditR(services);
            AddDepedency(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

        private void AddDepedency(IServiceCollection services)
        {
            services.AddSingleton<IEventStore<Core.Entities.Booking.Booking>, EventStore<Core.Entities.Booking.Booking>>();
            services.AddTransient<IBookingService, BookingService>();
        }
        private void AddMeditR(IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateBookingCommand));
        }
    }
}
