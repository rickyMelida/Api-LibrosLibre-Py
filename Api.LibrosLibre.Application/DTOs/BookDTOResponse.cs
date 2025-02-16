namespace Api.LibrosLibre.Application
{
    public class BookDTOResponse : BookDTO
    {
        public string UserName { get; set; }
        public List<string> Images { get; set; } 
    }
}