using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.LibrosLibre.Domain 
{
	[Table("users_book", Schema = "books_free_py")]
    public class UserBook {
        [Key]
		[Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		
		[Column("_user")]
        public int User { get; set; }
		
		[Column("book")]
        public int Book { get; set; }
    }
}
