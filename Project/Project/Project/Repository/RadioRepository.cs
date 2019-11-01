using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Repository
{
    public class RadioRepository: IRepository<Radio>
    {
            DBContext DC = new DBContext();

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
            public void Delete(string key)
            {
                using (DC)
                {
                    Radio c = DC.Radio_Stations.Find(Convert.ToInt32(key));
                    DC.Radio_Stations.Remove(c);
                }
            }
            public Radio Get(string key)
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
                using (DC)
                {
                    DC.Radio_Stations.Update(item);
                }
            }
        }
    }
