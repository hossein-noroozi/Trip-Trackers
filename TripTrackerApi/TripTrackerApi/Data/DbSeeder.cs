using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTracker_BackService.Models;

namespace TripTrackerApi.Data
{
    public class DbSeeder
    {
        /// <summary>
        /// seeds a couple of data 
        /// </summary>
        /// <param name="context"></param>
        #region Trip Seeder
        public static void Seeder(TripContext context)
        {
            context.Database.EnsureCreated();
            context.Trips.AddRange(new Trip[]
            {
                new Trip()
                {
                    Id = 1,
                    Name = "Dubai Trip",
                    StartDate = new DateTime(2018, 3, 8),
                    EndDate = new DateTime(2018, 3, 17)
                },
                new Trip()
                {
                    Id = 2,
                    Name = "London",
                    StartDate = new DateTime(2018, 4, 10),
                    EndDate = new DateTime(2018, 4, 20)

                },
                new Trip()
                {
                    Id = 3,
                    Name = "Sweeden",
                    StartDate = new DateTime(2018, 9, 25),
                    EndDate = new DateTime(2018, 10, 7)

                }
            }
                 );
            context.SaveChanges();
        }
        #endregion


        
    }
}
