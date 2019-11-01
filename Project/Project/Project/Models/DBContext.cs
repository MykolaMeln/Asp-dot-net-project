using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class DBContext : IdentityDbContext<User>
    {
        public DBContext(DbContextOptions<DBContext> options)
               : base(options)
        { }
        public DBContext()
        {
            Database.EnsureCreated();
        }
       public DbSet<User> Users { get; set; }
        public DbSet<Radio> Radio_Stations { get; set; }
        public DbSet<Prohram> Prohrams { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=radioss;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /* modelBuilder.Entity<User>(entity =>
             {
                 entity.HasKey(e => e.UserId);
                 entity.Property(e => e.UserName).IsRequired().HasMaxLength(30);             
                 entity.Property(e => e.Email).IsRequired().HasMaxLength(40);
                 //   entity.HasOne(e => e.UserId).WithOne(j => j.).HasForeignKey<Manager>(k => k.userId);
                 //  entity.HasOne(d => d.UserId).WithMany(p => p.).HasForeignKey(d => d.userid).HasConstraintName("FK_Addresses_Towns");
             });
             */
            modelBuilder.Entity<Radio>(entity =>
            {
                entity.HasKey(e => e.RadioId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(20);
                //  entity.HasOne(d => d.UserId).WithMany(p => p.).HasForeignKey(d => d.userid).HasConstraintName("FK_Addresses_Towns");
            });

            modelBuilder.Entity<Prohram>(entity =>
            {
                entity.HasKey(e => e.ProgramId);
                entity.Property(e => e.Name_program).IsRequired().HasMaxLength(30);
                //  entity.HasOne(d => d.UserId).WithMany(p => p.).HasForeignKey(d => d.userid).HasConstraintName("FK_Addresses_Towns");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasKey(e => e.RatingId);
                entity.HasKey(e => new { e.userid, e.stationid });
                // entity.HasOne(d => d.RatingId).WithMany(p => p.).HasForeignKey(d => d.userid).HasConstraintName("FK_Addresses_Towns");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasKey(e => new { e.userid, e.stationid });
                // entity.HasOne(d => d.RatingId).WithMany(p => p.).HasForeignKey(d => d.userid).HasConstraintName("FK_Addresses_Towns");
            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.commentid);
                // entity.HasOne(d => d.RatingId).WithMany(p => p.).HasForeignKey(d => d.userid).HasConstraintName("FK_Addresses_Towns");
            });
        }
    }
}
