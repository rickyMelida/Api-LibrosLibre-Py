namespace Api.Domain 
{
    public class BookRequest {
        public int Id { get; set; }
        public int UserInteresed { get; set; }
        public int OwnerBook { get; set; }
        public int Book { get; set; }
        public int Transaction { get; set; }
    }
}
