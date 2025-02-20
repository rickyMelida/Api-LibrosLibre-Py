using Api.LibrosLibre.Application;
using Api.LibrosLibre.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.LibrosLibre.Persistence
{
    public class FavoriteRepository: IFavoriteRepository
    {
        private readonly AppDbContext _context;

        public FavoriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Favorite> SetFavorite(Favorite favorite)
        {
            await _context.Favorites.AddAsync(favorite);
            return favorite;
        }

        public Task<Favorite> DeleteFavorite(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Favorite> GetFavoriteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Favorite>> GetFavorites()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Favorite>> GetFavoritesByUserId(int userId)
        {
            var favorites = await _context.Favorites.Where(x => x.User == userId).ToListAsync();
            if (favorites == null || !favorites.Any())
            {
                return new List<Favorite>();
            }
            return favorites;
        }

        public Task<Favorite> UpdateFavorite(Favorite favorite)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetLastId()
        {
            return await _context.Favorites.AnyAsync() ? await _context.Favorites.MaxAsync(x => x.Id) : 0;
        }
    }
}