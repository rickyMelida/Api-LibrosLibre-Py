using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<bool> CreateUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<int> GetLastId();
    }
}
