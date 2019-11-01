using System;
using System.Collections.Generic;
using System.Text;
using Project.DAL.Entities;

namespace Project.DAL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Radio> Radios { get; }
        IRepository<Prohram> Prohrams { get; }
        IRepository<Comment> Comments { get; }
        IRepository<User> Users { get; }
        IRepository<Rating> Ratings { get; }
        IRepository<Favorite> Favorites { get; }
        void Save();
    }
}
