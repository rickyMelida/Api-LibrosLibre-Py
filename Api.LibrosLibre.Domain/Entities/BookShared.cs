namespace Api.LibrosLibre.Domain 
{
    public class BookShared {
        public int Id { get; set; }
        public int Book { get; set; }
        public int User { get; set; }
        public int WayShared { get; set; }
        public DateTime SharedDate { get; set; }
    }
}
