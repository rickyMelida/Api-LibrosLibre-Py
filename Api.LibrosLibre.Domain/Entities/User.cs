using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.LibrosLibre.Domain 
{
    [Table("users", Schema = "books_free_py")]
	public class User 
	{
        [Key]
		[Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		[Column("name")]
        public string Name { get; set; }

		[Column("email")]
        public string Email { get; set; }

		[Column("phone_number")]
        public string Phone { get; set; }

		[Column("uid")]
		public string Uid { get; set; }	    
	
	}
}