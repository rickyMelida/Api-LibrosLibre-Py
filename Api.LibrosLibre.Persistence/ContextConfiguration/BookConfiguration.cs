using Api.LibrosLibre.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.LibrosLibre.Persistence
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book", "public");

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Author).HasColumnName("author").IsRequired();
            builder.Property(x => x.Available).HasColumnName("available").IsRequired();
            builder.Property(x => x.LitleDescription).HasColumnName("litle_description");
            builder.Property(x => x.Title).HasColumnName("title");
            builder.Property(x => x.OtherDetails).HasColumnName("other_detail");
            builder.Property(x => x.Price).HasColumnName("price");
            builder.Property(x => x.State).HasColumnName("state");
            builder.Property(x => x.TransactionType).HasColumnName("transaction_type");
            builder.Property(x => x.UploadDate).HasColumnName("upload_date");
            builder.Property(x => x.Year).HasColumnName("year");
        }
    }
}
