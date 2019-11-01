using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Repository
{
   public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(string key);
        void Create(T item);
        void Update(T item);
        void Delete(string key);
    }
}
