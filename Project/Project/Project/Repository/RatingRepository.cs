using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Repository
{
    public class RatingRepository : IRepository<Rating>
    {
        DBContext DC = new DBContext();

        public RatingRepository(DBContext context)
        {
            this.DC = context;
        }
        public void Create(Rating item)
        {
            using (DC)
            {
                DC.Ratings.Add(item);
            }
        }
        public void Delete(string key)
        {
            using (DC)
            {
                Rating c = DC.Ratings.Find(Convert.ToInt32(key));
                DC.Ratings.Remove(c);
            }
        }
        public Rating Get(string key)
        {
            using (DC)
            {
                return DC.Ratings.Find(Convert.ToInt32(key));
            }
        }
        public IEnumerable<Rating> GetAll()
        {
            using (DC)
            {
                return DC.Ratings;
            }
        }
        public void Update(Rating item)
        {
            using (DC)
            {
                DC.Ratings.Update(item);
            }
        }
    }
}
