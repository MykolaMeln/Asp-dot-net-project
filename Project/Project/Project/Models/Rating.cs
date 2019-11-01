using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int userid { get; set; }
        public int stationid { get; set; }
        public int rating { get; set; }
    }
}
