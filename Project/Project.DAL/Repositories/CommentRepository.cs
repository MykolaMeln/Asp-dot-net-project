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
    public class CommentRepository : IRepository<Comment>
    {
        private DBContext DC;

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
        public void Delete(int key)
        {
            using (DC)
            {
                Comment c = DC.Comments.Find(Convert.ToInt32(key));
                DC.Comments.Remove(c);
            }
        }
        public Comment Get(int key)
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
            DC.Entry(item).State = EntityState.Modified;
        }
        public IEnumerable<Comment> Find(Func<Comment, Boolean> predicate)
        {
            return DC.Comments.Where(predicate).ToList();
        }
    }
}
