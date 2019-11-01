using Project.DAL.EF;
using Project.DAL.Entities;
using Project.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Project.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
         DBContext DC = new DBContext();

         public UserRepository(DBContext context)
        {
            this.DC = context;
        }
        IEnumerable<User> IRepository<User>.GetAll()
        {
            return DC.Users;
        }

        void IRepository<User>.Create(User item)
        {
            using (DC)
            {
                DC.Users.Add(item);
            }
        }
        void IRepository<User>.Delete(int key)
        {
            using (DC)
            {
                User c = DC.Users.Find(key);
                DC.Users.Remove(c);
            }
        }
        User IRepository<User>.Get(int key)
        {
            using (DC)
            {
                return DC.Users.Find(Convert.ToInt32(key));
            }
        }
        public void Update(User item)
        {
           DC.Entry(item).State = EntityState.Modified;
        }
        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return DC.Users.Where(predicate).ToList();
        }
    }
}
