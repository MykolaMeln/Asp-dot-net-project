using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Repository
{
    public class ProhramRepository : IRepository<Prohram>
    {
        DBContext DC = new DBContext();

        public ProhramRepository(DBContext context)
        {
            this.DC = context;
        }
        public void Create(Prohram item)
        {
            using (DC)
            {
                DC.Prohrams.Add(item);
            }
        }
        public void Delete(string key)
        {
            using (DC)
            {
                Prohram c = DC.Prohrams.Find(Convert.ToInt32(key));
                DC.Prohrams.Remove(c);
            }
        }
        public Prohram Get(string key)
        {
            using (DC)
            {
                return DC.Prohrams.Find(Convert.ToInt32(key));
            }
        }
        public IEnumerable<Prohram> GetAll()
        {
            using (DC)
            {
                return DC.Prohrams;
            }
        }
        public void Update(Prohram item)
        {
            using (DC)
            {
                DC.Prohrams.Update(item);
            }
        }
    }
}
