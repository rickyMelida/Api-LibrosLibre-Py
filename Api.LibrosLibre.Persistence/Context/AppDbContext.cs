using Api.LibrosLibre.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.LibrosLibre.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<BookState> BookStates { get; set; }
        public DbSet<TypeTransaction> TypeTransactions { get; set; }
        public DbSet<Favorite> Favorites { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    		modelBuilder.Entity<Book>().ToTable("books", schema: "books_free_py");
			modelBuilder.Entity<Image>().ToTable("images", schema: "books_free_py");
			modelBuilder.Entity<User>().ToTable("users", schema: "books_free_py");
			modelBuilder.Entity<UserBook>().ToTable("users_book", schema: "books_free_py");
			modelBuilder.Entity<BookState>().ToTable("book_states", schema: "books_free_py");
			modelBuilder.Entity<TypeTransaction>().ToTable("type_transaction", schema: "books_free_py");
			modelBuilder.Entity<Favorite>().ToTable("favorites", schema: "books_free_py");
        }
    }
}
