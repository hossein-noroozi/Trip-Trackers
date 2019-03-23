using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using TripTrackerApi.Data;
using Microsoft.Data.Sqlite;

namespace TripTrackerApi
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
            //Adding my Database service 
            services.AddDbContext<TripContext>(opt =>
            opt.UseSqlServer(@"Server=.;Database=TripDB;Trusted_Connection=True;"), ServiceLifetime.Transient);

            // Add A in memory database
            //services.AddTransient<Repository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Adding Swagger Gen Options
            services.AddSwaggerGen(opt =>
            opt.SwaggerDoc("v1", new Info { Title = "TripTracker", Version = "v1" })
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env , TripContext context)
        {
            //Adding swagger and swagger UI options
            app.UseSwagger();

            // just for safty of your data try to envoierment that you need swagger UI in
            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseSwaggerUI(opt =>
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Trip Tracker v1")
                );

            }



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //DbSeeder.Seeder(context);

            app.UseMvc();

            //using building method in context for our seed data
            TripContext.SeedMethod(app.ApplicationServices);
        }
    }
}
