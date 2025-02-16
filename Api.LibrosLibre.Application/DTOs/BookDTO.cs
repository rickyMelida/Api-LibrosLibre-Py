namespace Api.LibrosLibre.Application
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Price { get; set; }
        public int State { get; set; }
        public int TransactionType { get; set; }
        public string Description { get; set; }
        public string? OtherDetail { get; set; }
        public string? Year { get; set; }
    }
}
