using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IFavoriteRepository
    {
        Task<List<Favorite>> GetFavorites();
        Task<Favorite> GetFavoriteById(int id);
        Task<List<Favorite>> GetFavoritesByUserId(int userId);
        Task<Favorite> SetFavorite(Favorite favorite);
        Task<Favorite> UpdateFavorite(Favorite favorite);
        Task<Favorite> DeleteFavorite(int id);
        Task<int> GetLastId();
    }
}
