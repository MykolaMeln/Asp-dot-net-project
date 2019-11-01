using Project.DAL.EF;
using Project.DAL.Entities;
using Project.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        DBContext DC = new DBContext();
        private RadioRepository radioRepository;
        private UserRepository userRepository;
        private ProhramRepository prohramRepository;
        private RatingRepository ratingRepository;
        private CommentRepository commentRepository;
        private FavoriteRepository favoriteRepository;

        IRepository<Radio> IUnitOfWork.Radios
        {
            get
            {
                if (radioRepository == null)
                    radioRepository = new RadioRepository(DC);
                return radioRepository;
            }
        }

        IRepository<Prohram> IUnitOfWork.Prohrams
        {
            get
            {
                if (prohramRepository == null)
                    prohramRepository = new ProhramRepository(DC);
                return prohramRepository;
            }
        }

        IRepository<Comment> IUnitOfWork.Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(DC);
                return commentRepository;
            }
        }


        IRepository<User> IUnitOfWork.Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(DC);
                return userRepository;
            }
        }

        IRepository<Rating> IUnitOfWork.Ratings
        {
            get
            {
                if (ratingRepository == null)
                    ratingRepository = new RatingRepository(DC);
                return ratingRepository;
            }
        }

        IRepository<Favorite> IUnitOfWork.Favorites
        {
            get
            {
                if (favoriteRepository == null)
                    favoriteRepository = new FavoriteRepository(DC);
                return favoriteRepository;
            }
        }

        public void Save()
        {
           DC.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DC.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
