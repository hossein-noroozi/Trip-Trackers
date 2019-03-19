using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripTracker_BackService.Models;

namespace TripTrackerApi.Data
{
    public class Repository
    {
        private List<Trip> MyTrips = new List<Trip>
        {
            new Trip
            {
                Id = 1,
                Name = "Dubai Trip",
                StartDate = new DateTime(2018 , 3 , 8),
                EndDate = new DateTime(2018 , 3 , 17)
            },

            new Trip
            {
                Id = 2,
                Name = "London",
                StartDate = new DateTime(2018 , 4 , 10),
                EndDate = new DateTime(2018 , 4 , 20)
            },

            new Trip
            {
                Id=3,
                Name="Sweeden",
                StartDate=new DateTime(2018 , 9 , 25),
                EndDate=new DateTime(2018,10,7)
            }

        };

        public List<Trip> Get()
        {
            return MyTrips;
        }

        public Trip GetById(int id)
        {
            return MyTrips.First(t => t.Id == id);
        }

        public void Add(Trip newTrip)
        {
            MyTrips.Add(newTrip);
        }

        public void Update(Trip tripToUpdate)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == tripToUpdate.Id));
            Add(tripToUpdate);
        }

        public void Remove(int id)
        {
            MyTrips.Remove(MyTrips.First(t => t.Id == id));
        }
    }
}
