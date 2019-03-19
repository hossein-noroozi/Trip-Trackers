using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripTracker_BackService.Models
{
    public class Segment : BaseModel
    {
        public Segment()
        {

        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int TripId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }


    }
}
