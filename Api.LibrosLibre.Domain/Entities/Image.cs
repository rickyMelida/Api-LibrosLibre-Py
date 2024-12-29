namespace Api.LibrosLibre.Domain {
    public class Image {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public int BookId { get; set; }
    }

}