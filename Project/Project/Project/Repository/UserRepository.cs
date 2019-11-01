using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Repository
{
    public class UserRepository : IRepository<User>
    {
        DBContext DC = new DBContext();

        public UserRepository(DBContext context)
        {
            this.DC = context;
        }
        public void Create(User item)
        {
            using (DC)
            {
                DC.Users.Add(item);
            }
        }
        public void Delete(string key)
        {
            using (DC)
            {
                User c = DC.Users.Find(key);
                DC.Users.Remove(c);
            }
        }
        public User Get(string key)
        {
            using (DC)
            {
                return DC.Users.Find(Convert.ToInt32(key));
            }
        }
        public IEnumerable<User> GetAll()
        {
            using (DC)
            {
                return DC.Users;
            }
        }
        public void Update(User item)
        {
            using (DC)
            {
                DC.Users.Update(item);
            }
        }
    }
}
