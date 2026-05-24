using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain;
using AutoMapper;

namespace Api.LibrosLibre.Application.Mappings
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserDTO>();
			CreateMap<UserDTO, User>();
		}
	}
}