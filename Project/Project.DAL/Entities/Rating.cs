using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Entities
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int userid { get; set; }
        public int stationid { get; set; }
        public int rating { get; set; }
    }
}
