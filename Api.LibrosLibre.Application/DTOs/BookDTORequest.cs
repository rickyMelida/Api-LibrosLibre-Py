using Microsoft.AspNetCore.Http;

namespace Api.LibrosLibre.Application
{
    public class BookDTORequest : BookDTO
    {
        public int User { get; set; }
        public List<IFormFile> Images { get; set; }
        
    }
}