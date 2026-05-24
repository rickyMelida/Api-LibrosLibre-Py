using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application 
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsers();
        Task<UserDTO> GetUserById(int id);
        Task<UserDTO> GetUserByUid(string id);
        Task<UserDTO> GetUserByMail(dynamic mail);
        Task<UserDTO> CreateUser(UserDTO user);
        Task<UserDTO> UpdateUser(UserDTO user);
        Task<bool> DeleteUser(int id);
        Task<bool> IsUserValid(UserDTO user);
    }

}