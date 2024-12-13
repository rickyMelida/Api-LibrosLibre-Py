namespace Api.LibrosLibre.Application
{
    public interface IWayShareRepository
    {
        Task<List<WayShare>> GetWayShares();
        Task<WayShare> GetWayShareById(int id);
        Task<bool> CreateWayShare(WayShare wayShare);
        Task<bool> UpdateWayShare(WayShare wayShare);
        Task<bool> DeleteWayShare(int id);
    }
}
