using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.LibrosLibre.Domain 
{
	[Table("images", Schema = "books_free_py")]
    public class Image {
        [Key]
		[Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		[Column("description")]
        public string Description { get; set; }
        
		[Column("picture")]
        public byte[] Picture { get; set; }
		
        [Column("book")]
        public int BookId { get; set; }
    }
}