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
    public class FavoriteRepository : IRepository<Favorite>
    {
        private DBContext DC;

        public FavoriteRepository(DBContext context)
        {
            this.DC = context;
        }
        public void Create(Favorite item)
        {
            using (DC)
            {
                DC.Favorites.Add(item);
            }
        }
        public void Delete(int key)
        {
            using (DC)
            {
                Favorite c = DC.Favorites.Find(Convert.ToInt32(key));
                DC.Favorites.Remove(c);
            }
        }
        public Favorite Get(int key)
        {
            using (DC)
            {
                return DC.Favorites.Find(Convert.ToInt32(key));
            }
        }
        public IEnumerable<Favorite> GetAll()
        {
            using (DC)
            {
                return DC.Favorites;
            }
        }
        public void Update(Favorite item)
        {
            DC.Entry(item).State = EntityState.Modified;
        }
        public IEnumerable<Favorite> Find(Func<Favorite, Boolean> predicate)
        {
            return DC.Favorites.Where(predicate).ToList();
        }
    }
}
