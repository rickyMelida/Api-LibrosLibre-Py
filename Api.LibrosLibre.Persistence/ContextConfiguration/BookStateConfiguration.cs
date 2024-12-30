using Api.LibrosLibre.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.LibrosLibre.Persistence
{
    public class BookStateConfiguration : IEntityTypeConfiguration<BookState>
    {
        public void Configure(EntityTypeBuilder<BookState> builder)
        {
            builder.ToTable("book_states", "public");

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Description).HasColumnName("description");
        }
    }
}