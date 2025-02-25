using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application 
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByMail(dynamic mail);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<bool> IsUserValid(User user);
    }

}