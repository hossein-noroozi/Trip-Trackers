using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTracker_BackService.Models;

namespace TripTrackerApi.Data
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions options) : base(options)
        {

        }

        public TripContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=.;Database=TripDB;Trusted_Connection=False;");
            }
        }




        public DbSet<Trip> Trips { get; set; }


        /// <summary>
        /// My Seeds
        /// </summary>
        /// <param name="serviceProvider"></param>
        #region Seeding data
        public static void SeedMethod(IServiceProvider serviceProvider)
        {

            using (var serviceScope = serviceProvider
                 .GetRequiredService<IServiceScopeFactory>().CreateScope())
            {

                var context = serviceScope
                    .ServiceProvider.GetService<TripContext>();

                context.Database.EnsureCreated();

                if (context.Trips.Any())
                {
                    return;
                }

                context.Trips.AddRange(new Trip[]
                    {
                    new Trip
                    {
                        Name = "Dubai Trip",
                        StartDate = new DateTime(2018 , 3 , 8),
                        EndDate = new DateTime(2018 , 3 , 17)
                    },

                    new Trip
                    {
                        Name = "London",
                        StartDate = new DateTime(2018 , 4 , 10),
                        EndDate = new DateTime(2018 , 4 , 20)
                    },

                    new Trip
                    {
                        Name="Sweeden",
                        StartDate=new DateTime(2018 , 9 , 25),
                        EndDate=new DateTime(2018,10,7)
                    }
                    });
                context.SaveChanges();
            }
        }
        #endregion
    }
}
