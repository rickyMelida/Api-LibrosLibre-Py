using Api.LibrosLibre.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.LibrosLibre.Persistence
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("favorites", "public");

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.User).HasColumnName("user");
            builder.Property(x => x.Book).HasColumnName("book");
        }
    }
}