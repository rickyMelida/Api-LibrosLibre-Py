namespace Api.LibrosLibre.Domain {
    public class Rating {
        public int Id { get; set; }
        public int Book { get; set; }
        public int User { get; set; }
        public int Score { get; set; }
    }
}
