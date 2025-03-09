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
            try
            {
                bool existsUser = await _userRepository.IsUserValid(user);

                if (existsUser) return null;
                
                user.Id = await _userRepository.GetLastId() + 1;
                await _userRepository.CreateUser(user);
                await _unitOfWork.Save();

                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User> GetUserByMail(dynamic mail)
        {
            return await _userRepository.GetUserByMail(mail);
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsUserValid(User user)
        {
            return await _userRepository.IsUserValid(user);
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }

}