using Project.DAL.EF;
using Project.DAL.Entities;
using Project.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Project.DAL.Repositories
{
    public class RadioRepository : IRepository<Radio>
    {
        private DBContext DC;

        public RadioRepository(DBContext context)
        {
            this.DC = context;
        }
        public void Create(Radio item)
        {
            using (DC)
            {
                DC.Radio_Stations.Add(item);
            }
        }
        public void Delete(int key)
        {
            using (DC)
            {
                Radio c = DC.Radio_Stations.Find(Convert.ToInt32(key));
                DC.Radio_Stations.Remove(c);
            }
        }
        public Radio Get(int key)
        {
            using (DC)
            {
                return DC.Radio_Stations.Find(Convert.ToInt32(key));
            }
        }
        public IEnumerable<Radio> GetAll()
        {
            using (DC)
            {
                return DC.Radio_Stations;
            }
        }
        public void Update(Radio item)
        {
            DC.Entry(item).State = EntityState.Modified;
        }
        public IEnumerable<Radio> Find(Func<Radio, Boolean> predicate)
        {
            return DC.Radio_Stations.Where(predicate).ToList();
        }
    }
}
