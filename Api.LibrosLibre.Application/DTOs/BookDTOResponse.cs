namespace Api.LibrosLibre.Application.DTOs
{
    public class BookDTOResponse : BookDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<string> Images { get; set; } 
    }
}