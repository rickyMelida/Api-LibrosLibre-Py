using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IRatingRepository
    {
        Task<List<Rating>> GetRatings();
        Task<Rating> GetRatingById(int id);
        Task<bool> CreateRating(Rating rating);
        Task<bool> UpdateRating(Rating rating);
        Task<bool> DeleteRating(int id);
    }
}
