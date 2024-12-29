namespace Api.LibrosLibre.Persistence {
    using Api.LibrosLibre.Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("public", "images");

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Picture).HasColumnName("image");
            builder.Property(x => x.BookId).HasColumnName("book_id").IsRequired();

        }
    }

}