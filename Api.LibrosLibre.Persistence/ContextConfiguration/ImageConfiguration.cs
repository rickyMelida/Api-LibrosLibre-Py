using Api.LibrosLibre.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.LibrosLibre.Persistence
{

    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("image", "public");

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Picture).HasColumnName("picture");
            builder.Property(x => x.BookId).HasColumnName("book_id").IsRequired();

        }
    }

}