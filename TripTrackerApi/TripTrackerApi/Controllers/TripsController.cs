using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripTracker_BackService.Models;
using TripTrackerApi.Data;

namespace TripTracker_BackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private Repository _repository;
        public TripsController(Repository repository)
        {
            _repository = repository;
        }

        // Get api / Trip 
        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return _repository.Get();
        }

        [HttpGet("{id}")]
        public Trip GetTripById(int id)
        {
            return _repository.GetById(id);
        }

        // post api / Trips
        [HttpPost]
        public void Post([FromBody]Trip trip)
        {
            _repository.Add(trip);
        }

        // put api / Trips
        [HttpPut("{id}")]
        public void Put(Trip trip)
        {
            _repository.Update(trip);
        }

        // delete api / Trips
        [HttpDelete]
        public void Delete(int id)
        {
            _repository.Remove(id);
        }
    }
}