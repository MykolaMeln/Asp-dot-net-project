using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Repository
{
    public class FavoriteRepository : IRepository<Favorite>
    {
        DBContext DC = new DBContext();

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
        public void Delete(string key)
        {
            using (DC)
            {
                Favorite c = DC.Favorites.Find(Convert.ToInt32(key));
                DC.Favorites.Remove(c);
            }
        }
        public Favorite Get(string key)
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
            using (DC)
            {
                DC.Favorites.Update(item);
            }
        }
    }
}
