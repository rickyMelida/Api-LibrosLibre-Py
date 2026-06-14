namespace Api.LibrosLibre.Application.DTOs
{
	public class ImageDTO 
	{
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public int BookId { get; set; }
		public bool IsPrincipal { get; set; }
    }

	public class ImagePrincipalDTO
	{
		public string Picture { get; set; }
		public bool IsPrincipal { get; set; }
	}
}