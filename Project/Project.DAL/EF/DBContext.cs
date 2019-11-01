using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Project.DAL.EF
{
      public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
               : base(options)
        { }
        public DBContext()
        {
            Database.EnsureCreated();
        }
        public System.Data.Entity.DbSet<Radio> Radio_Stations { get; set; }
        public System.Data.Entity.DbSet<Prohram> Prohrams { get; set; }
        public System.Data.Entity.DbSet<Comment> Comments { get; set; }
        public System.Data.Entity.DbSet<User> Users { get; set; }
        public System.Data.Entity.DbSet<Rating> Ratings { get; set; }
        public System.Data.Entity.DbSet<Favorite> Favorites { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Radio>().HasKey(i => i.RadioId);
            builder.Entity<User>().HasKey(i => i.Id);
            builder.Entity<Rating>().HasKey(i => i.RatingId);
            builder.Entity<Prohram>().HasKey(i => i.ProgramId);
            builder.Entity<Comment>().HasKey(i => i.commentid);

            builder.Entity<User>().Property(a => a.UserName).HasMaxLength(30);
            builder.Entity<Prohram>().Property(a => a.Name_program).HasMaxLength(30);
            builder.Entity<Comment>().Property(a => a.comment).HasMaxLength(200);    
        }

    }
}