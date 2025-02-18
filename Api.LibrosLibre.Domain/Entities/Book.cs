namespace Api.LibrosLibre.Domain 
{
    public class Book 
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public bool Available { get; set; }
        public string LitleDescription { get; set; }
        public string Title { get; set; }
        public string OtherDetails { get; set; }
        public int Price { get; set; }
        public int State { get; set; }
        public int TransactionType { get; set; }
        public DateTime UploadDate {get; set;}
        public string Year { get; set; }
    }
}