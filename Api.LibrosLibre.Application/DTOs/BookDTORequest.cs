using Microsoft.AspNetCore.Http;

namespace Api.LibrosLibre.Application.DTOs
{
    public class BookDTORequest : BookDTO
    {
        public int User { get; set; }
        public List<IFormFile> Images { get; set; }
		public string PrincipalImage { get; set; }
        
    }
}