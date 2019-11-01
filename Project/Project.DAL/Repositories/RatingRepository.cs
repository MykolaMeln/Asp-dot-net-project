using Microsoft.EntityFrameworkCore;
using Project.DAL.EF;
using Project.DAL.Entities;
using Project.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.DAL.Repositories
{
    public class RatingRepository : IRepository<Rating>
    {
        private DBContext DC;

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
        public void Delete(int key)
        {
            using (DC)
            {
                Rating c = DC.Ratings.Find(Convert.ToInt32(key));
                DC.Ratings.Remove(c);
            }
        }
        public Rating Get(int key)
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
            DC.Entry(item).State = EntityState.Modified;
        }
        public IEnumerable<Rating> Find(Func<Rating, Boolean> predicate)
        {
            return DC.Ratings.Where(predicate).ToList();
        }
    }
}
