using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project.Models;

namespace Project.Repository
{
    public class CommentRepository : IRepository<Comment>
    {
        DBContext DC = new DBContext();

        public CommentRepository(DBContext context)
        {
            this.DC = context;
        }
        public void Create(Comment item)
        {
            using (DC)
            {
                DC.Comments.Add(item);
            }
        }
        public void Delete(string key)
        {
            using (DC)
            {
                Comment c = DC.Comments.Find(Convert.ToInt32(key));
                DC.Comments.Remove(c);
            }
        }
        public Comment Get(string key)
        {
            using (DC)
            {
                return DC.Comments.Find(Convert.ToInt32(key));
            }
        }
        public IEnumerable<Comment> GetAll()
        {
            using (DC)
            {
                return DC.Comments;
            }
        }
        public void Update(Comment item)
        {
            using (DC)
            {
                DC.Comments.Update(item);
            }
        }
    }
}
