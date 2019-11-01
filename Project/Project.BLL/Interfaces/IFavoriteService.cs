using Project.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.BLL.Interfaces
{
    interface IFavoriteService
    {
        void ChooseFavorite(FavoriteDTO faviriteDto);
        UserDTO GetFavorite(int? id);
        IEnumerable<FavoriteDTO> GetFavorites();
        void Dispose();
    }
}
