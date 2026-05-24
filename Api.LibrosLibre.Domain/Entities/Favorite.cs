using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.LibrosLibre.Domain 
{
	[Table("favorites", Schema = "books_free_py")]
    public class Favorite {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int User { get; set; }
        
		public int Book { get; set; }
    }
}