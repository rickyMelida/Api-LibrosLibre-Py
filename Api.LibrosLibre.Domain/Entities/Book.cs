using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.LibrosLibre.Domain 
{
	[Table("books", Schema = "books_free_py")]
    public class Book 
    {
		[Key]
		[Column("id")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Column("author")]
		public string Author { get; set; }

		[Column("available")]
		public bool Available { get; set; }

		[Column("litle_description")]
		public string LitleDescription { get; set; }

		[Column("title")]
		public string Title { get; set; }

		[Column("other_detail")]
		public string OtherDetail { get; set; }

		[Column("price")]
		public int Price { get; set; }

		[Column("state")]
		public int State { get; set; }

		[Column("transaction_type")]
		public int TransactionType { get; set; }

		[Column("upload_date")]
		public DateOnly UploadDate { get; set; }

		[Column("year")]
		public string Year { get; set; }
    }
}