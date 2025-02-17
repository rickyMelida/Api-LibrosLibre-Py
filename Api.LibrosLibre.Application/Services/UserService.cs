using Api.LibrosLibre.Domain;

namespace Api.LibrosLibre.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork) =>
            (_userRepository, _unitOfWork) = (userRepository, unitOfWork);
             
        public async Task<User> CreateUser(User user)
        {
            await _userRepository.CreateUser(user);
            await _unitOfWork.Save();
            
            return user;
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }

}