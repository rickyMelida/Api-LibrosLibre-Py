using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain;
using AutoMapper;

namespace Api.LibrosLibre.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper) =>
            (_userRepository, _unitOfWork, _mapper) = (userRepository, unitOfWork, mapper);

        public async Task<UserDTO> CreateUser(UserDTO user)
        {
            try
            {
				var userEntity = _mapper.Map<User>(user);
                bool existsUser = await _userRepository.IsUserValid(userEntity);

                if (existsUser) return null;
                
                await _userRepository.CreateUser(userEntity);
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

		public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByMail(dynamic mail)
        {
            var user = await _userRepository.GetUserByMail(mail);
            return _mapper.Map<UserDTO>(user);
        }

		public Task<UserDTO> GetUserByUid(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<UserDTO> GetUserByUid(string uid)
		{
			var user = await _userRepository.GetUserByUid(uid);
			return _mapper.Map<UserDTO>(user);
		}

		public Task<List<UserDTO>> GetUsers()
		{
			throw new NotImplementedException();
		}

		public async Task<bool> IsUserValid(UserDTO user)
        {
			var userEntity = _mapper.Map<User>(user);
            return await _userRepository.IsUserValid(userEntity);
        }

		public Task<UserDTO> UpdateUser(UserDTO user)
		{
			throw new NotImplementedException();
		}
	}
}