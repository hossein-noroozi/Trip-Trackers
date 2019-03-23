using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripTracker_BackService.Models;
using TripTrackerApi.Data;

namespace TripTracker_BackService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        // this lazy loading was for my in memory repository context
        //private Repository _repository;
        //public TripsController(Repository repository)
        //{
        //    _repository = repository;
        //}

        //this lazy loading is for my sqlite db context
        private TripContext _context;
        public TripsController(TripContext context)
        {
            _context = context;
        }

        // Get api / Trip 
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var trips = await _context.Trips.AsNoTracking().ToListAsync();
            return Ok(trips);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var trip = await _context.Trips.FindAsync(id);
            return Ok(trip);
        }

        // post api / Trips
        [HttpPost]
        public async Task<IActionResult> OnPostAsync([FromBody]Trip trip)
        {
            await _context.Trips.AddAsync(trip);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                return BadRequest("sorry somthing went wrong");
            }
            return Ok("the register was Sucssecfull");
        }

        // put api / Trips
        [HttpPut("{id}")]
        public async Task<IActionResult> OnPutAsync(Trip trip, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Sorry somthing went wrong");
            }
            if (!_context.Trips.Any(opt => opt.Id == id))
            {
                return NotFound("Sorry we did not found your data");
            }
            _context.Trips.Update(trip);
            await _context.SaveChangesAsync();
            return Ok("Update has been succsesfull");
        }

        // delete api / Trips
        [HttpDelete("{id}")]
        public async Task<IActionResult> OnDeleteAsync(int id)
        {
            var trip = _context.Trips.Find(id);
            if (trip == null)
            {
                return NotFound("Sorry we did not found your data");
            }
            try
            {
                _context.Trips.Remove(trip);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                return BadRequest("Sorry we could not delete your data");
            }
            return Ok("Delete has been succsesfull");
        }
    }
}