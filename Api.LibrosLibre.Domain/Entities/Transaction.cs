namespace Api.LibrosLibre.Domain {
    public class Transaction {
        public int Id { get; set; }
        public string Observation { get; set; }
        public bool Complete { get; set; }
        public DateTime Date { get; set; }
        public int Type { get; set; }
    }
}