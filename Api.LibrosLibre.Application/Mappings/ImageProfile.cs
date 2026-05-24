using Api.LibrosLibre.Application.DTOs;
using Api.LibrosLibre.Domain;
using AutoMapper;

namespace Api.LibrosLibre.Application.Mappings
{
	public class ImageProfile : Profile
	{
		public ImageProfile()
		{
			CreateMap<Image, ImageDTO>();
			CreateMap<ImageDTO, Image>();
		}
	}
}