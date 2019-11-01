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
    public class ProhramRepository : IRepository<Prohram>
    {
        private DBContext DC;

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
        public void Delete(int key)
        {
            using (DC)
            {
                Prohram c = DC.Prohrams.Find(Convert.ToInt32(key));
                DC.Prohrams.Remove(c);
            }
        }
        public Prohram Get(int key)
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
            DC.Entry(item).State = EntityState.Modified;
        }
        public IEnumerable<Prohram> Find(Func<Prohram, Boolean> predicate)
        {
            return DC.Prohrams.Where(predicate).ToList();
        }
    }
}
