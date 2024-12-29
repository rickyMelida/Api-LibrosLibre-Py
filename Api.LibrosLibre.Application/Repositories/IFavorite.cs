using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IFavoriteRepository
    {
        Task<List<Favorite>> GetFavorites();
        Task<Favorite> GetFavoriteById(int id);
        Task<bool> CreateFavorite(Favorite favorite);
        Task<bool> UpdateFavorite(Favorite favorite);
        Task<bool> DeleteFavorite(int id);
    }
}
